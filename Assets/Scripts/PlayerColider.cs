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

        if (other.gameObject.CompareTag("Warp"))
        {
            Warp warp = other.gameObject.GetComponent<Warp>();

            playerController.SetState(PlayerController.playerState.Teleporting);
            playerController.setTeleportTimer(warp.DestinationPosition, other.gameObject.transform.position);
            
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("ForceWalk"))
        {
            playerController.SetState(PlayerController.playerState.ForceWalk);
            Vector3 forward = other.transform.forward;
            Vector3 dir = new Vector3(forward.z, 0f, -forward.x);
            playerController.setForceWalkForward(dir);
        }

        if (other.CompareTag("VerticleObstrucle"))
        {
            playerController.SetState(PlayerController.playerState.Claiming);
        }

        if (other.CompareTag("Stair"))
            playerController.SetState(PlayerController.playerState.ClaimingStair);

        if (other.CompareTag("Warp"))
            playerController.SetState(PlayerController.playerState.Teleporting);
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("ForceWalk"))
            playerController.SetState(PlayerController.playerState.Idle);

        if (other.CompareTag("Floor"))
            playerController.isGroud = false;

        if (other.CompareTag("VerticleObstrucle")) {
            playerController.SetState(PlayerController.playerState.Idle);
        }

        if (other.CompareTag("Stair"))
        {
            playerController.SetState(PlayerController.playerState.Idle);
        }



    }
}
