using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerController : MonoBehaviour {

    Vector3 forward;
    Rigidbody rb;
    SphereCollider co;

    public enum playerState {Idle, Running, Claiming, Air, Dead, StageClear};

    public Text[] arr_text;

    public Transform head;
    public float speed = 1f;
    public float runningMultiplyer = 2f;
    public float jumpForce = 100f;

    public playerState state = playerState.Idle;
    public bool isGroud = false;

    float currentSpeed;

    private int Score = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();
        co = GetComponent<SphereCollider>();
    }

    void Update() {

        Debug.Log(state);

        forward = new Vector3(head.forward.x, 0, head.forward.z);
        forward = forward / forward.magnitude;


    }

    void FixedUpdate()
    {
        checkSprint();
        checkInput();
        checkFall();
    }

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("box"))
		{
			//other.gameObject.SetActive (false);
			Application.LoadLevel ("Level Select");
		}
	}


    public void checkInput()
    {
        Debug.Log("Check Input");
        if (state == playerState.Idle || state == playerState.Air)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(forward.x * currentSpeed, rb.velocity.y, forward.z * currentSpeed);
            }

            if (Input.GetKey(KeyCode.S))
                rb.velocity = new Vector3(-forward.x * currentSpeed, rb.velocity.y, -forward.z * currentSpeed);

            if (Input.GetKey(KeyCode.A))
                rb.velocity = new Vector3(-forward.z * currentSpeed, rb.velocity.y, forward.x * currentSpeed);

            if (Input.GetKey(KeyCode.D))
                rb.velocity = new Vector3(forward.z * currentSpeed, rb.velocity.y, -forward.x * currentSpeed);
        }
        else if(state == playerState.Claiming)
        {
            if (Input.GetKey(KeyCode.W))
                rb.velocity = new Vector3(0, currentSpeed, 0);
            else if (Input.GetKey(KeyCode.S))
            {
                if (!isGroud)
                    rb.velocity = new Vector3(0, -currentSpeed, 0);
                else
                    rb.velocity = new Vector3(-forward.x * currentSpeed, rb.velocity.y, -forward.z * currentSpeed);
            }
            else
                rb.velocity = new Vector3(0, 0, 0);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha2)) && state != playerState.Claiming && state != playerState.Air)
        {
            state = playerState.Air;
            rb.AddForce(jumpForce * Vector3.up);
        }
    }

    public void checkSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Alpha5))
            currentSpeed = speed * runningMultiplyer;
        else
            currentSpeed = speed;
    }

    public void checkFall()
    {
        if(transform.position.y <= -50)
        {
            //Dead >> Result popup
            transform.position = new Vector3(0, 1, 0);
        }
    }

    public void getStar()
    {
        Score++;
    }




    
}