
﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainController : MonoBehaviour {

    private bool gazed = false;
    private string scene = "";
	private Color colorStart = Color.yellow;
	private Color colorEnd = Color.white;
	private TextMesh text;
    public GameObject cardboard;
    public GameObject mainMenu, levelSelectMenu,StartText,SetText,Credit,HowText;

    public enum playerState { MainMenu, LevelSelect, MovingToLevelSelect, MovingToMainMenu, MovingToStage }

    private playerState state;

    void Start() {
        state = playerState.MainMenu;
		text = GetComponent<TextMesh>();
		text.color = colorStart;
    }
    // Update is called once per frame
    void Update() {
		if (state == playerState.MainMenu) {
			if ((Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.Alpha2)) && gazed) {
				switch (scene) {
				case "play game":
					state = playerState.MovingToLevelSelect;
					mainMenu.SetActive (false);
					    
					break;
				case "s01l01":
					Debug.Log ("Stage 1, Level 1");
					MapGenerator.numbers = MapDataArray.getData () [0] [0];
					MapGenerator.level = 1;
					MapGenerator.stage = 1;
					Application.LoadLevel ("Generator");
					break;
				case "s01l02":
					Debug.Log ("Stage 1, Level 2");
					MapGenerator.numbers = MapDataArray.getData () [0] [1];
					MapGenerator.level = 1;
					MapGenerator.stage = 2;
					Application.LoadLevel ("Generator");
					break;
				case "s01l03":
					Debug.Log ("Stage 1, Level 3");
					MapGenerator.numbers = MapDataArray.getData () [0] [2];
					MapGenerator.level = 1;
					MapGenerator.stage = 3;
					Application.LoadLevel ("Generator");
					break;
				}
			}
		} else if (state == playerState.MovingToLevelSelect) {
			cardboard.transform.position = Vector3.Lerp (cardboard.transform.position, new Vector3 (0, 1, 50), 0.5f * Time.deltaTime);
			if (cardboard.transform.position.z >= 33.5f) {
				state = playerState.LevelSelect;
				levelSelectMenu.SetActive (true);
				StartText.SetActive (false);
				SetText.SetActive (false);
				Credit.SetActive (false);
				HowText.SetActive (false);
			}
		} else if (state == playerState.LevelSelect) {
			if (Input.GetKeyDown (KeyCode.A) && gazed) {
				switch (scene) {
				case "back":
					state = playerState.MovingToMainMenu;
					levelSelectMenu.SetActive (false);
					StartText.SetActive (true);
					SetText.SetActive (true);
					Credit.SetActive (true);
					HowText.SetActive (true);
					break;
				case "1":
					state = playerState.MovingToStage;
					break;
				case "2":
					state = playerState.MovingToStage;
					break;
				case "3":
					state = playerState.MovingToStage;
					break;
				}
			}
		} else if (state == playerState.MovingToMainMenu) {
			cardboard.transform.position = Vector3.Lerp (cardboard.transform.position, new Vector3 (0, 1, -2), 0.5f * Time.deltaTime);
			if (cardboard.transform.position.z <= 0f) {
				state = playerState.MainMenu;
				mainMenu.SetActive (true);

			}
		}

        Debug.Log("state: " + state);
    }


    public void OnPointerEnter(string name) {
        Debug.Log("On Pointer Enter: " + name);
        gazed = true;
        scene = name;
		text.color = colorEnd;
    }

    public void OnPointerExit() {
        gazed = false;
		text.color = colorStart;
    }

}
