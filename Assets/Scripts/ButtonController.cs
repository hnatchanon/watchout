using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour {

	public Image hilight;
    public Button[] menus;
    public Text[] texts;
    public Button s1;
	public Button s2;
	public Button s3;

    private int index;
	
	void Start()
	{
        index = 0;
        SetHilight(0);
		//blist.Add (s1);
		//blist.Add (s2);
		//blist.Add (s3);
		//cur = blist [0];
		//cur.GetComponent<Image> ().color = Color.blue;
        //hilight.rectTransform;
		//Debug.Log (cur);
		//Debug.Log ("POPPY");
	   
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.DownArrow) && index < menus.Length-1) {
            SetHilight(+1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && index > 0) {
            SetHilight(-1);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(index);
            //changeScence(cur.name);
        }
    }
    private void SetHilight(int i) {
        texts[index].color = Color.white;
        index += i;
        texts[index].color = Color.black;
        hilight.rectTransform.position = menus[index].targetGraphic.rectTransform.position + new Vector3(0f, -0.02f, 0f);
    }

    public void changeScence(string current_name) {
        if (current_name == "Button1")
            Application.LoadLevel("Stage 2");
        else if (current_name == "Button2")
            Application.LoadLevel(Application.loadedLevelName);
        else if (current_name == "Button3")
            Application.LoadLevel("Main Menu");

    }
}
