using UnityEngine;
using System.Collections;


public class TextController : MonoBehaviour {

	public TextMesh text;
	private bool color;
	private Color newColor = new Color32 (73, 255, 245, 255);

	// Use this for initialization
	void Start () {
		//text = GetComponents<TextMesh>();
		text.color = Color.white;
		color = true;
		InvokeRepeating("ChangeColor", 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void ChangeColor () {

		Debug.Log (text.color);

		if (color) {
			//Debug.Log ("Change1");
			text.color = newColor;
			color = false;
		}

		else if (!color) {
			//Debug.Log ("Change2");
			text.color = Color.white;
			color = true;
		}

	
	}
}
