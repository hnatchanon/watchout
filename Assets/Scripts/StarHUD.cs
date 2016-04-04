using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarHUD : MonoBehaviour {

    public PlayerController player;

    private Text text;
    private int starCount = 0;

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        starCount = player.GetStarCount();
        text.text = string.Format("Star: {0}",starCount);
        Debug.Log(starCount);
    }
}
