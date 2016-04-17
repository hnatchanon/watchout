using UnityEngine;
using System.Collections;

public class FootColider : MonoBehaviour {


    public PlayerController playerController;
    private Rigidbody rb;
	public SoundManager sm;

    void Start ()
    {
        rb = playerController.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
            playerController.SetState(PlayerController.playerState.Idle);
        if (other.CompareTag("MovingPlane")) {
            playerController.gameObject.transform.parent = other.gameObject.transform.parent;
        }
        if (other.CompareTag("EnergyBall") && playerController.getState() != PlayerController.playerState.StageClear)
        {
			sm.playSound (SoundManager.soundclip.Coll);
            Destroy(other.gameObject);
            playerController.gameObject.GetComponent<Rigidbody>().AddForce(other.transform.forward * 500);
        }

    }

    void OnTriggerStay(Collider other) {

    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("MovingPlane"))
            playerController.gameObject.transform.parent = null;
    }

}
