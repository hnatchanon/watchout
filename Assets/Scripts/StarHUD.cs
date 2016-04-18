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
        text.text = string.Format("Ring: {0}/3",starCount);
    }
}
