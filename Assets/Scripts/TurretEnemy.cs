using UnityEngine;
using System.Collections;

public class TurretEnemy : MonoBehaviour {

    public Transform gunTransform;
    public GameObject bullet;

    public float frequent = 1f;
    public float destroyIn = 1.0f;

    private float timer;

	// Use this for initialization
	void Start () {
        timer = frequent;
	}
	
	// Update is called once per frame
	void Update () {
        if( timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = frequent;
            Shoot();
        }
        
    }

    private void Shoot()
    {
        Debug.Log("LifeTime: " + destroyIn);
        GameObject go = (GameObject)Instantiate(bullet, gunTransform.position, gunTransform.rotation);
        //Debug.Log(gunTransform.forward);
        Destroy(go, destroyIn);
        
    }
}
