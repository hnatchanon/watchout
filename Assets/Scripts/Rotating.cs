using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour {

    public Vector3 axis = Vector3.up;
    public float speed = 150;

	// Use this for initialization
	void Start () {
	    
	}
	// Update is called once per frame
	void Update () {
        transform.Rotate(axis, speed * Time.deltaTime);
	}
}
