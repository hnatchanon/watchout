﻿using UnityEngine;
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

    float currentSpeed;

    private playerState state = playerState.StageStart;
    private int starCount = 0;
    private Vector3 destinationPosition;
    private Vector3 lerpPosition;
    private Vector3 ForceWalkForward;

    private float StartStageTimeLeft;
    


    void Start() {
        state = playerState.StageStart;
        Freeze();
        rb = GetComponent<Rigidbody>();
        co = GetComponent<SphereCollider>();
        result.SetActive(false);
        dead.SetActive(false);
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
    }

    private void CheckFreeze()
    {
        Debug.Log(StartStageTimeLeft);
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
            Move(ForceWalkForward);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha2)) && state != playerState.Claiming && state != playerState.Air && state != playerState.Teleporting && state != playerState.Claiming && state != playerState.ClaimingStair && state != playerState.ForceWalk ) {
            state = playerState.Air;
            rb.AddForce(jumpForce * Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            RestartScene();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            SetState(PlayerController.playerState.StageClear);
            result.SetActive(true);
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
            currentSpeed = speed * 1.5f;
        //Debug.Log(currentSpeed);
    }

    public void CheckFall() {
        if (transform.position.y <= -50) {

            dead.SetActive(true);
            //rb.MovePosition(new Vector3(0, 1, 0));
        }
    }

    public void CollectStar() {
        starCount++;
    }

    public int GetStarCount() {
        return starCount;
    }

    public void SetState(playerState state) {
        if (this.state == state || this.state == playerState.StageStart) {
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
                teleportTimeLeft = -99;
                transform.position = destinationPosition;
                SetState(playerState.Idle);
            }
        }
    }

    public void setTeleportTimer(Vector3 destinationPosition, Vector3 lerpPosition) {
        teleportTimeLeft = 3;
        this.destinationPosition = destinationPosition;
        this.lerpPosition = lerpPosition;
    }

    public void setForceWalkForward(Vector3 forward) {
        this.ForceWalkForward = forward;
    }
    
}