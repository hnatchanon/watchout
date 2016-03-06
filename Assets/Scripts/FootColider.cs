using UnityEngine;
using System.Collections;

public class FootColider : MonoBehaviour {


    public PlayerCotroller playerController;
    private Rigidbody rb;
    void Start ()
    {
        rb = playerController.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Floor"))
            playerController.setIsJumping(false);
        
    }

}
