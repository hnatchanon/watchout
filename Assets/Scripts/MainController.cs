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
            if (Input.GetKeyDown(KeyCode.Q) && gazed) {
                switch (scene) {
                    case "Game":
                        state = playerState.MovingToLevelSelect;
                        mainMenu.SetActive(false);
                        break;
                }
            }
        }
        else if (state == playerState.MovingToLevelSelect || Input.GetKeyDown(KeyCode.S)) {
            cardboard.transform.position = Vector3.Lerp(cardboard.transform.position, new Vector3(0, 1, 12), 0.5f * Time.deltaTime);
            if (cardboard.transform.position.z >= 12f) {
                state = playerState.LevelSelect;
                levelSelectMenu.SetActive(true);
            }
        }

        Debug.Log(state);
    }


    public void OnPointerEnter(string name) {
        //Debug.Log ("OnPointEnter");
        gazed = true;
        scene = name;
    }

    public void OnPointerExit() {
        gazed = false;
    }

}
