using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	public Button s1;
	public Button s2;
	public Button s3;
	private Button cur;
	private Button pre;
	private int preIndex;
	List<Button> blist = new List<Button>();




	public void changeScence(string current_name)
	{
        if (current_name == "Button1")
            Application.LoadLevel("Stage 2");
        else if (current_name == "Button2")
            Application.LoadLevel(Application.loadedLevelName);
        else if (current_name == "Button3")
            Application.LoadLevel("Main Menu");

    }
	void Start()
	{
		blist.Add (s1);
		blist.Add (s2);
		blist.Add (s3);
		foreach (Button b in blist) {
			b.GetComponent<Image> ().color = Color.grey;
		}
		cur = blist [0];
		cur.GetComponent<Image> ().color = Color.green;
		//Debug.Log (cur);
		//Debug.Log ("POPPY");
	   
	}

	void FindIndex (){
		for (int i = 0; i < blist.Count; i++) {

			if (blist [i] == cur) {
				preIndex = i;
				break;
			}
		}
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			FindIndex ();

			if (preIndex + 1 > blist.Count-1) 
				cur = blist [0];
			else 
				cur = blist [preIndex + 1];
			
			
			pre = blist[preIndex];
			cur.GetComponent<Image> ().color = Color.green;
			pre.GetComponent<Image> ().color = Color.grey;

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			FindIndex ();
			if (preIndex - 1 < 0) 
				cur = blist [2];
			else 
				cur = blist[preIndex - 1];
			

			pre = blist[preIndex];
			cur.GetComponent<Image> ().color = Color.green;
			pre.GetComponent<Image> ().color = Color.grey;
		

		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log (cur.name);
		   changeScence (cur.name);
		}
			
	}
}
