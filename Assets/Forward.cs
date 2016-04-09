using UnityEngine;
using System.Collections;

public class Forward : MonoBehaviour {
    public float speed = 10;

	// Update is called once per frame
	void Update () {
        transform.position = transform.position + transform.forward * Time.deltaTime * speed;
	}
}
