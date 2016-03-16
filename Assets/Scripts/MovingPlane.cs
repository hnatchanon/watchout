using UnityEngine;
using System.Collections;

public class MovingPlane : MonoBehaviour {

    public float gridSize = 4f;
    public Vector3 direction;
    public float speed = 1f;

    private float addedPosition;
    private float __i = 0f;
    private float __x, __y, __z;
    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        __x = transform.position.x;
        __y = transform.position.y;
        __z = transform.position.z;
    }

    // Update is called once per frame
    void Update() {
        float tmp = (__i += 0.01f * speed) % 2;
        if (tmp < 1) {
            addedPosition = tmp * gridSize;
        }
        else {
            addedPosition = (2 - tmp) * gridSize;
        }

        float tmpX = __x + (addedPosition * direction.x * gridSize);
        float tmpY = __y + (addedPosition * direction.y * gridSize);
        float tmpZ = __z + (addedPosition * direction.z * gridSize);
        //rb.MovePosition(new Vector3(tmpX, tmpY, tmpZ));

        transform.position = new Vector3(tmpX, tmpY, tmpZ);
    }
}
