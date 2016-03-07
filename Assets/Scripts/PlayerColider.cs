using UnityEngine;
using System.Collections;

public class PlayerColider : MonoBehaviour {

    public PlayerController playerController;
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
            playerController.isGroud = true;

        if (other.CompareTag("Jumper"))
        {
            playerController.SetState(PlayerController.playerState.Air);
            rb.AddForce(new Vector3(0, jumpForce * 3, 0));
        }

        if (other.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
            playerController.GetStar();
        }

        if(other.CompareTag("Goal"))
        {
            playerController.SetState(PlayerController.playerState.StageClear);
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("VerticleObstrucle"))
        {
            playerController.SetState(PlayerController.playerState.Claiming);
        }
        //else
        //{
        //    playerController.setState(1);
        //}
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Floor"))
            playerController.isGroud = false;

        if (other.CompareTag("VerticleObstrucle")) {
            playerController.SetState(PlayerController.playerState.Idle);
        }

    }
}
