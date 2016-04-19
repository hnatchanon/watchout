using UnityEngine;
using System.Collections;

public class PlayerColider : MonoBehaviour {

    public PlayerController playerController;

    private Rigidbody rb;

    void Start()
    {
        rb = playerController.GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("On Trigger Enter: " + other.tag);
        if (other.CompareTag("Floor"))
            playerController.isGroud = true;

        if (other.CompareTag("Jumper"))
        {
            Debug.Log("JUMP!");
            rb.AddForce(playerController.jumpForce * Vector3.up * 2);
            playerController.SetState(PlayerController.playerState.Air);
        }

        if (other.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
            playerController.CollectStar();
        }

        if(other.CompareTag("Goal"))
        {
            if (playerController.GetStarCount() == 3) {
                playerController.SetState(PlayerController.playerState.StageClear);
                playerController.LerpToGoal(other.gameObject.transform.position);
            }
            //else
                // If not 3 star
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
        //Debug.Log("On Trigger Stay: " + other.tag);

        if (other.CompareTag("ForceWalk"))
        {
            if (playerController.getState() == PlayerController.playerState.ForceWalk)
                return;
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
