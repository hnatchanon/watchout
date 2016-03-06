using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerCotroller : MonoBehaviour {

    Vector3 forward;
    Rigidbody rb;
    SphereCollider co;

    public Text[] arr_text;

    public Transform head;
    public float speed = 1f;
    public float runningMultiplyer = 2f;
    public float jumpForce = 100f;

    public static bool isVerticle = false;
    public static bool isBottomVerticle = false;

    float currentSpeed;


    void Start() {
        rb = GetComponent<Rigidbody>();
        co = GetComponent<SphereCollider>();
    }

    void Update() {
        forward = new Vector3(head.forward.x, 0, head.forward.z);
        forward = forward / forward.magnitude;
    }
    void FixedUpdate() {

        if(transform.position.y <= -30)
        {
            transform.position = new Vector3(0, 2, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.Alpha5))
            currentSpeed = speed * runningMultiplyer;
        else
            currentSpeed = speed;

        Debug.Log(isVerticle);

        if (!isVerticle)
        {
            if (Input.GetKey(KeyCode.W))
                rb.velocity = new Vector3(forward.x * currentSpeed, rb.velocity.y, forward.z * currentSpeed);

            if (Input.GetKey(KeyCode.S))
                rb.velocity = new Vector3(-forward.x * currentSpeed, rb.velocity.y, -forward.z * currentSpeed);

            if (Input.GetKey(KeyCode.A))
                rb.velocity = new Vector3(-forward.z * currentSpeed, rb.velocity.y, forward.x * currentSpeed);

            if (Input.GetKey(KeyCode.D))
                rb.velocity = new Vector3(forward.z * currentSpeed, rb.velocity.y, -forward.x * currentSpeed);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
                rb.velocity = new Vector3(0, currentSpeed, 0);
            else if (Input.GetKey(KeyCode.S))
            {
                if (!isBottomVerticle)
                    rb.velocity = new Vector3(0, -currentSpeed, 0);
                else
                    rb.velocity = new Vector3(-forward.x * currentSpeed, rb.velocity.y, -forward.z * currentSpeed);
            }
            else
                rb.velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha2))
            rb.AddForce(jumpForce * Vector3.up);

        if (Input.GetKey(KeyCode.C)  || Input.GetKey(KeyCode.Alpha7))
        {
            if (co.radius <= 0.2f)
                co.radius = 0.2f;
            else
                co.radius -= 0.04f;
        }

        else
        {
            if (co.radius >= 0.5f)
                co.radius = 0.5f;
            else
                co.radius += 0.03f;
        }
    }

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("box"))
		{
			//other.gameObject.SetActive (false);
			Application.LoadLevel ("Level Select");
		}
	}


    public void setState(int state)
    {
        if (state == 0)
        {
            isVerticle = true;
            rb.useGravity = false;
        }
        else if (state == 1)
        {
            isVerticle = false;
            rb.useGravity = true;
        }
        else if (state == 2)
            isBottomVerticle = true;
        else if (state == 3)
            isBottomVerticle = false;
    }


    
}