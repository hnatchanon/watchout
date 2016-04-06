using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour {

	public Image hilight;
    public Button[] menus;
    public Text[] texts;

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

            menus[index].onClick.Invoke();
        }
    }
    private void SetHilight(int i) {
        texts[index].color = Color.white;
        index += i;
        texts[index].color = Color.black;
        hilight.rectTransform.position = menus[index].targetGraphic.rectTransform.position + new Vector3(0f, -0.02f, 0f);
    }

    public void changeScence(string name) {
        if(name == "next")
        {
            MapGenerator.nextLevel();
            Application.LoadLevel("Generator");
        }
        else if(name == "retry")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
            Application.LoadLevel(name);


    }
}
