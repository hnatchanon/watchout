using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerText : MonoBehaviour {

    private Text text;

    private static float time;

    public enum TimerState { running, pause };

    public TimerState state;

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
        time = 0f;
    }

    // Update is called once per frame
    void Update() {
        if (state == TimerState.running)
            time += Time.deltaTime;
        text.text = time.ToString("0") + " S";
    }

    public void Stop() {
        state = TimerState.pause;
    }

    public void Reset() {
        time = 0;
    }

    public float GetTime() {
        return time;
    }


    public static int[] getTime()
    {
        int[] array = new int[2];
        array[0] = (int)time / 60;
        array[1] = (int)time % 60;
        return array;
    }
    
}
