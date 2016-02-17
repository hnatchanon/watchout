using UnityEngine;
using System.Collections;

public class MovingPlane : MonoBehaviour {

    public float gridSize = 4f;
    public float movingLength;
    public bool isVertical = true;
    public float speed = 1f;

    private float addedPosition;
    private float __i = 0f;
    private float __y;
    private float __x;

    // Use this for initialization
    void Start() {
        __x = transform.position.x;
        __y = transform.position.y;
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

        if (isVertical) {
            transform.position = new Vector3(transform.position.x, __y + addedPosition, transform.position.z);
        }
        else {
            transform.position = new Vector3(__x + addedPosition, transform.position.y, transform.position.z);
        }
    }
}
