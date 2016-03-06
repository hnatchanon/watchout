using UnityEngine;
using System.Collections;

public class FootColider : MonoBehaviour {


    public PlayerController playerController;
    private Rigidbody rb;
    void Start ()
    {
        rb = playerController.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Foot Colider: " + other.name);
        if (other.CompareTag("Floor"))
            playerController.state = PlayerController.playerState.Idle;
        
    }

}
