using UnityEngine;
using System.Collections;

public class PlayerColider : MonoBehaviour {

    public PlayerCotroller playerController;
    public float jumpForce;

    private Rigidbody rb;

    void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Floor"))
            playerController.setState(2);

        if (other.CompareTag("Jumper"))
        {
            rb.AddForce(new Vector3(0, jumpForce * 3, 0));
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VerticleObstrucle"))
        {
            Debug.Log("VerticleObstucle");
            playerController.setState(0);
        }
        //else
        //{
        //    playerController.setState(1);
        //}
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Floor"))
            playerController.setState(3);

        if (other.CompareTag("VerticleObstrucle"))
            playerController.setState(1);

    }
}
