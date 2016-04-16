using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerController : MonoBehaviour {

    Vector3 forward;
    Rigidbody rb;
    SphereCollider co;

    public enum playerState { Idle, Running, Claiming, Air, Dead, StageClear, ClaimingStair, Teleporting, ForceWalk, StageStart };

    public Text[] arr_text;

    private float teleportTimeLeft = -99f;
    public Transform head;
    public float speed = 1f;
    public float runningMultiplyer = 2f;
    public float jumpForce = 125f;


    public bool isGroud = false;

    public GameObject result;
    public GameObject dead;
    public GameObject menu;
    private Minimap minimap;

    float currentSpeed;

    private playerState state = playerState.StageStart;
    private int starCount = 0;
    private Vector3 destinationPosition;
    private Vector3 lerpPosition;
    private Vector3 ForceWalkForward;

    private float StartStageTimeLeft;
	public SoundManager sm;
    


    void Start() {
        state = playerState.StageStart;
        //Freeze();
        rb = GetComponent<Rigidbody>();
        co = GetComponent<SphereCollider>();
        result.SetActive(false);
        dead.SetActive(false);

        //int level = 99;
        //int stage = 99;
        //int min = 80;
        //int sec = 70;
        //Debug.Log(getLeaderboardRecord(90, 90));
        //Debug.Log(getLeaderboardRecord(90, 90)[0] + " " + getLeaderboardRecord(90, 90)[1]);
    }

    private void Freeze()
    {
        state = playerState.StageStart;
        StartStageTimeLeft = 3f;
    }

    void Update() {
        forward = new Vector3(head.forward.x, 0, head.forward.z);
        forward = forward / forward.magnitude;


    }

    void FixedUpdate() {
        //Debug.Log("Player State: " + state);

        CheckFreeze();
        CheckSpeed();
        CheckInput();
        CheckFall();
        CheckTeleportTimer();
        CheckLerpToGoal();
    }

    private void CheckLerpToGoal()
    {
        if (state == playerState.StageClear)
        {
			sm.playSound (SoundManager.soundclip.Goal);
            transform.position = Vector3.Lerp(transform.position, lerpPosition, 1 * Time.deltaTime);
            float tranX = transform.position.x;
            float tranZ = transform.position.z;
            float lerpX = lerpPosition.x;
            float lerpZ = lerpPosition.z;
            if (Math.Abs(tranX - lerpX) <= 0.01 && Math.Abs(tranZ - lerpZ) <= 0.01)
            {
                result.SetActive(true);
                submitLeaderboard(MapGenerator.level, MapGenerator.stage, TimerText.getTime()[0], TimerText.getTime()[1]);
                Debug.Log(getLeaderboardRecord(MapGenerator.level, MapGenerator.stage)[0] + " " + getLeaderboardRecord(MapGenerator.level, MapGenerator.stage)[1]);
            }
        }
    }

    private void CheckFreeze()
    {
        if (StartStageTimeLeft == -99)
            return;

        if (StartStageTimeLeft < 0)
        {
            StartStageTimeLeft = -99;
            state = playerState.Idle;
        }
        else
            StartStageTimeLeft -= Time.deltaTime;
    }

    public void CheckInput() {



        if (state == playerState.Idle || state == playerState.Air || state == playerState.ClaimingStair) {
            if (Input.GetKey(KeyCode.W)) {
                Move(forward);
            }

            if (Input.GetKey(KeyCode.S))
                Move(new Vector3(-forward.x, 0, -forward.z));

            if (Input.GetKey(KeyCode.A))
                Move(new Vector3(-forward.z, 0, forward.x));

            if (Input.GetKey(KeyCode.D))
                Move(new Vector3(forward.z, 0, -forward.x));
        }
        else if (state == playerState.Claiming) {
            rb.useGravity = false;
            if (Input.GetKey(KeyCode.W))
                Move(new Vector3(forward.x / 2, speed / 2, forward.z / 2));
            else if (Input.GetKey(KeyCode.S)) {
                if (!isGroud)
                    Move(new Vector3(0, -speed / 2, 0));
                else
                    Move(new Vector3(-forward.x, 0, -forward.z));
            }
            else
                rb.velocity = new Vector3(0, 0, 0);
        }

        else if (state == playerState.ForceWalk) {
			sm.playSound (SoundManager.soundclip.ForceWalk);
            Move(ForceWalkForward);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha2)) && state != playerState.Claiming && state != playerState.Air && state != playerState.Teleporting && state != playerState.Claiming && state != playerState.ClaimingStair && state != playerState.ForceWalk && state != playerState.StageClear) {
            state = playerState.Air;
            rb.AddForce(jumpForce * Vector3.up);
			sm.playSound (SoundManager.soundclip.Jump);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            RestartScene();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            SetState(PlayerController.playerState.StageClear);
            result.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inGameMenu();
        }


    }

    private void Move(Vector3 direction) {
        rb.MovePosition(transform.position + direction * Time.deltaTime * currentSpeed);
    }

    public void CheckSpeed() {
        


        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Alpha5)) && state == playerState.Idle)
            currentSpeed = speed * runningMultiplyer;
        else
            currentSpeed = speed;

        if (state == playerState.ClaimingStair) {
            currentSpeed = speed * 2.5f;
        }

        if (state == playerState.Air) {
            currentSpeed = speed * 1;
        }

        if (state == playerState.ForceWalk)
            currentSpeed = speed * 2f;
        //Debug.Log(currentSpeed);
    }

    public void CheckFall() {
        if (transform.position.y <= -50) {

            dead.SetActive(true);
            //rb.MovePosition(new Vector3(0, 1, 0));
        }
    }

    public void CollectStar() {
		sm.playSound (SoundManager.soundclip.Star);
        starCount++;
    }

    public int GetStarCount() {
        return starCount;
    }

    public void SetState(playerState state) {
        if (this.state == state || this.state == playerState.StageStart || this.state == playerState.Dead || this.state == playerState.StageClear || this.state == playerState.Teleporting) {
            return;
        }

        if (state == playerState.Claiming) {
            rb.useGravity = false;
        }

        if (this.state == playerState.Claiming) {
            rb.useGravity = true;
        }

        this.state = state;
    }

    public void RestartScene() {

        Application.LoadLevel(Application.loadedLevelName);
    }

    public void CheckTeleportTimer() {
        if (teleportTimeLeft != -99) {
            if (teleportTimeLeft > 0) {
                teleportTimeLeft -= Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, lerpPosition, 1 * Time.deltaTime);
            }
            if (teleportTimeLeft <= 0) {
				sm.playSound (SoundManager.soundclip.Warp);
                teleportTimeLeft = -99;
                transform.position = destinationPosition;
                state = playerState.Idle;


			}
        }
    }

    public void setTeleportTimer(Vector3 destinationPosition, Vector3 lerpPosition) {
        teleportTimeLeft = 3;
        this.destinationPosition = destinationPosition;
        this.lerpPosition = lerpPosition;
    }

    public void LerpToGoal(Vector3 destination)
    {
        lerpPosition = destination;
        
    }

    public void setForceWalkForward(Vector3 forward) {
        ForceWalkForward = forward;
    }

    public void inGameMenu()
    {
        menu.SetActive(!menu.active);
        
    }

    private void submitLeaderboard(int level, int stage, int min, int sec)
    {
        Leaderboard.submitScore(level, stage, min, sec);
    }

    private int[] getLeaderboardRecord(int level, int stage)
    {
        return Leaderboard.getLeaderboard(level, stage);
    }

    public playerState getState()
    {
        return state;
    }
    
}