using UnityEngine;
using System.Collections;

public class StageScript : MonoBehaviour {
    private Vector3 startingPosition;

    void Start() {
    }

    public void SetGazedAt(bool gazedAt) {
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;

    }
}
