﻿using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {
	
	private bool gazed = false;
	private string scene = "";
	private Color colorStart = Color.yellow;
    private Color colorEnd = Color.white;
	private Renderer rend;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer>();
		rend.material.color = colorStart;
	
	}
	
	// Update is called once per frame
	void Update () {

		//Application.LoadLevel (scene);
	
	}
	
	public void OnPointerEnter(/*string scene*/){
	
			gazed = true;
			//scene = scene;
			rend.material.color = colorEnd;
	
		}

	public void OnPointerExit() {
		gazed = false;
		rend.material.color = colorStart;

	}
}