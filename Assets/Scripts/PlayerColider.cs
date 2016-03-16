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
            playerController.CollectStar();
        }

        if(other.CompareTag("Goal"))
        {
            playerController.SetState(PlayerController.playerState.StageClear);
        }

        if (other.gameObject.CompareTag("box"))
        {
            //other.gameObject.SetActive (false);
            Application.LoadLevel("Level Select");
        }

    }

    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("VerticleObstrucle"))
        {
            playerController.SetState(PlayerController.playerState.Claiming);
        }

        if (other.CompareTag("Stair"))
            playerController.SetState(PlayerController.playerState.ClaimingStair);

    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Floor"))
            playerController.isGroud = false;

        if (other.CompareTag("VerticleObstrucle")) {
            playerController.SetState(PlayerController.playerState.Idle);
        }

        if (other.CompareTag("Stair"))
        {
            playerController.SetState(PlayerController.playerState.Air);
        }



    }
}
