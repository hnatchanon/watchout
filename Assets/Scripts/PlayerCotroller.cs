using UnityEngine;
using System.Collections;

public class PlayerCotroller : MonoBehaviour {

    Vector3 forward;
    Rigidbody rb;
    SphereCollider co;

    public Transform head;
    public float speed = 1f;
    public float runningMultiplyer = 2f;
    public float jumpForce = 100f;

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
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            currentSpeed = speed * runningMultiplyer;
        else
            currentSpeed = speed;

        if (Input.GetKey(KeyCode.W))
            rb.velocity = currentSpeed * new Vector3(forward.x, rb.velocity.y, forward.z);

        if (Input.GetKey(KeyCode.S))
            rb.velocity = currentSpeed * new Vector3(-forward.x, rb.velocity.y, -forward.z);

        if (Input.GetKey(KeyCode.A))
            rb.velocity = currentSpeed * new Vector3(-forward.z, rb.velocity.y, forward.x);

        if (Input.GetKey(KeyCode.D))
            rb.velocity = currentSpeed * new Vector3(forward.z, rb.velocity.y, -forward.x);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(jumpForce * Vector3.up);

        if (Input.GetKey(KeyCode.C)) {
            if (co.radius <= 0.2f)
                co.radius = 0.2f;
            else
                co.radius -= 0.04f;
        }

        else {
            if (co.radius >= 0.5f)
                co.radius = 0.5f;
            else
                co.radius += 0.03f;
        }
    }
}
