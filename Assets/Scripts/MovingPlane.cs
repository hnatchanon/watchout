using UnityEngine;
using System.Collections;

public class MovingPlane : MonoBehaviour {

    public float gridSize = 4f;
    public float movingLength;
    public Vector3 direction;
    public float speed = 1f;

    private float addedPosition;
    private float __i = 0f;
    private float __x, __y, __z;
    private Rigidbody rb;
    private Vector3 destination;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        __x = transform.position.x;
        __y = transform.position.y;
        __z = transform.position.z;

        destination = transform.position + direction * movingLength;
    }

    // Update is called once per frame
    void Update() {
        float tmp = (__i += 0.01f * speed) % 2;
        if (tmp < 1) {
            addedPosition = tmp * gridSize * movingLength;
        }
        else {
            addedPosition = (2 - tmp) * gridSize * movingLength;
        }

        float tmpX = __x + (addedPosition * direction.x);
        float tmpY = __y + (addedPosition * direction.y);
        float tmpZ = __z + (addedPosition * direction.z);
        //rb.MovePosition(new Vector3(tmpX, tmpY, tmpZ));

        transform.position = new Vector3(tmpX, tmpY, tmpZ);
    }
}
