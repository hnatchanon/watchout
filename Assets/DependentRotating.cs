using UnityEngine;
using System.Collections;

public class DependentRotating : MonoBehaviour {

    public GameObject dependee;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, dependee.transform.rotation.z/2f));
    }
}
