using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {
	
	private bool gazed = false;
	private string scene = "";
	private Color colorStart = Color.yellow;
    private Color colorEnd = Color.white;
	private TextMesh text;

	// Use this for initialization
	void Start () {

		text = GetComponent<TextMesh>();
		text.color = colorStart;
	
	}
	
	// Update is called once per frame
	void Update () {

		//Application.LoadLevel (scene);
	
	}
	
	public void OnPointerEnter(/*string scene*/){
	
			gazed = true;
        //scene = scene;
        text.color = colorEnd;
	
		}

	public void OnPointerExit() {
		gazed = false;
        text.color = colorStart;

	}
}
