using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {

    public float force = 1000f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, force, 0));
    }
}
