using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainController : MonoBehaviour {

    private bool gazed = false;
    private string scene = "";
    public GameObject cardboard;
    public GameObject mainMenu, levelSelectMenu;

    public enum playerState { MainMenu, LevelSelect, MovingToLevelSelect, MovingToMainMenu }

    private playerState state;

    void Start() {
        state = playerState.MainMenu;
    }
    // Update is called once per frame
    void Update() {
        if (state == playerState.MainMenu) {
            if (Input.GetKeyDown(KeyCode.A) && gazed) {
                switch (scene) {
                    case "play game":
                        state = playerState.MovingToLevelSelect;
                        mainMenu.SetActive(false);
                        break;
                    case "s01l01":
                        Debug.Log("Stage 1, Level 1");
                        MapGenerator.numbers = MapGenerator.numbers1;
                        Application.LoadLevel("Generator");
                        Debug.Log(Application.loadedLevelName);
                        break;
                }
            }
        }
        else if (state == playerState.MovingToLevelSelect) {
            cardboard.transform.position = Vector3.Lerp(cardboard.transform.position, new Vector3(0, 1, 12), 0.5f * Time.deltaTime);
            if (cardboard.transform.position.z >= 10f) {
                state = playerState.LevelSelect;
                levelSelectMenu.SetActive(true);
            }
        }
        else if (state == playerState.LevelSelect) {
            if (Input.GetKeyDown(KeyCode.A) && gazed) {
                switch (scene) {
                    case "back":
                        state = playerState.MovingToMainMenu;
                        levelSelectMenu.SetActive(false);
                        break;
                }
            }
        }
        else if (state == playerState.MovingToMainMenu) {
            cardboard.transform.position = Vector3.Lerp(cardboard.transform.position, new Vector3(0, 1, -2), 0.5f * Time.deltaTime);
            if (cardboard.transform.position.z <= 0f) {
                state = playerState.MainMenu;
                mainMenu.SetActive(true);
            }
        }

        Debug.Log("state: " + state);
    }


    public void OnPointerEnter(string name) {
        Debug.Log("On Pointer Enter: " + name);
        gazed = true;
        scene = name;
    }

    public void OnPointerExit() {
        gazed = false;
    }

}
