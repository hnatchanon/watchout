using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {
	
	private bool gazed = false;
	private string scene = "";
	private Color colorStart = Color.yellow;
    private Color colorEnd = Color.white;
	public GameObject cardboard;

    private Renderer rend;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer>();
        rend.material.color = colorStart;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A) && gazed) {
			cardboard.transform.position = Vector3.Lerp(cardboard.transform.position, new Vector3(0, 1, 50), 0.5f * Time.deltaTime);

			//Application.LoadLevel (scene);

		}

	
	}
	
	public void OnPointerEnter(/*string scene*/){
	
		gazed = true;
       
        rend.material.color = colorEnd;
	
		}

	public void OnPointerExit() {
		gazed = false;
        rend.material.color = colorStart;

	}
}
