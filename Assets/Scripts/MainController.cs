﻿
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    private bool gazed = false;
    private string scene = "";
    private Color colorStart = Color.yellow;
    private Color colorEnd = Color.white;
	private Color starEnter = new Color32 (73, 255, 245, 255);
	private Color starExit = new Color32 (108, 108, 108, 255);
    private TextMesh text;
    public GameObject cardboard;
    public GameObject mainMenu, levelSelectMenu, StartText, SetText, Credit, HowText, BackFromHowToPlay, BackFromCredit, BackFromSetting, BackFromLevel1, BackFromLevel2, BackFromLevel3, CreditMesh, SettingMesh;

    public enum playerState {Level1, Level2, Level3, MainMenu, Setting, HowToPlay, Credit, LevelSelect, MovingToLevelSelect, MovingToMainMenu, MovingToStage, Moving }

    private Dictionary<string, Vector3> PositionDict = new Dictionary<string, Vector3>();
    private Dictionary<string, playerState> StateDict = new Dictionary<string, playerState>();

    private playerState state;
    private playerState nextState;
    private Vector3 destination;
    private Vector3 destinationPrime;
    private Vector3 level1 = new Vector3(0, 1.5f, 35.4f);
    private Vector3 level2 = new Vector3(2, 1.5f, 33.4f);
    private Vector3 level3 = new Vector3(-2, 1.5f, 33.4f);
    private Vector3 menuSelect = new Vector3(0, 1, 0);
    private Vector3 levelSelect = new Vector3(0, 1, 33.4f);
    private Vector3 setting = new Vector3(2, 1, 0);
    private Vector3 credit = new Vector3(0, 1, -2);
    private Vector3 howToPlay = new Vector3(-2, 1, 0);

    private Renderer stageRenderer;
    public TextManager textManager;
	public SoundManager sm;

    public Toggle bgmToggle;
    public Toggle fxToggle;
    public Text settingLanguageText;

    public Text stageNameHUD, BestTimeHUD, TimeHUD;
    public Material stageColorEnter, stageColorExit;



    void Start()
    {
        state = playerState.MainMenu;
        text = GetComponent<TextMesh>();
        text.color = colorStart;
        initDict();

        //textManager.LogAllEngWords();
        initSetting();
        hideLeaderboardHUD();
    }




    void Update()
    {

        //Debug.Log("Camera State: " + state);
        if (state == playerState.Moving)
        {
			sm.playSound (SoundManager.soundclip.Dash,0.000000000001f);
            cardboard.transform.position = Vector3.Lerp(cardboard.transform.position, destinationPrime, Time.deltaTime);
            if((destination - cardboard.transform.position).magnitude <= 0.05f)
            {
				sm.stopSound ();
				
                setState(nextState);
                cardboard.transform.position = destination;
            }
        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Alpha2)) && gazed)
            {
                Debug.Log("Scene Var: " + scene);
				sm.playSound (SoundManager.soundclip.PointEnter);

                if(PositionDict.ContainsKey(scene) && StateDict.ContainsKey(scene))
                {
                    nextState = StateDict[scene];
                    moveCameraTo(PositionDict[scene]);
                }
                else if(scene == "bgm")
                {
                    string bgm;
                    bgmToggle.isOn = !bgmToggle.isOn;
                    if (bgmToggle.isOn)
                        bgm = "TRUE";
                    else
                        bgm = "FALSE";
                    PlayerPrefs.SetString("BGM", bgm);

                    updateBGMMute();
                }
                else if (scene == "fx")
                {
                    string fx;
                    fxToggle.isOn = !fxToggle.isOn;
                    if (fxToggle.isOn)
                        fx = "TRUE";
                    else
                        fx = "FALSE";
                    PlayerPrefs.SetString("FX", fx);
                }
                else if (scene == "setting_langugage")
                {
                    if(settingLanguageText.text == "ENGLISH")
                        setLanguage("THAI");
                    if (settingLanguageText.text == "THAI")
                        setLanguage("ENGLISH");
                }
                else
                    LoadMapGenerator(scene);

            }
        }
    }

    public void LoadMapGenerator(string levelStage)
    {
        string[] stringArr = levelStage.Split('S');
        int level = int.Parse(stringArr[0]);
        int stage = int.Parse(stringArr[1]);

        MapGenerator.numbers = MapDataArray.getData()[level-1][stage-1];
        MapGenerator.level = level;
        MapGenerator.stage = stage;
        Application.LoadLevel("Generator");
        
    }

    public void OnPointerEnter(string name)
    {
        Debug.Log("On Pointer Enter: " + name);
        gazed = true;
        scene = name;
        text.color = colorEnd;
		sm.playSound (SoundManager.soundclip.Cursor);

        GameObject go = GameObject.Find(name);
        if (go)
        {
            string[] arr = name.Split('S');
            int stage = int.Parse(arr[0]);
            int level = int.Parse(arr[1]);
            int min = -1;
            int sec = -1;
            int[] leaderboardRecord = Leaderboard.getLeaderboard(stage, level);
            if (leaderboardRecord != null)
            {
                min = leaderboardRecord[0];
                sec = leaderboardRecord[1];
                Debug.Log(name + " Leaderboard. Min: " + leaderboardRecord[0] + " Sec: " + leaderboardRecord[1]);
            }
            else
                Debug.Log("Leaderboard does't exist.");

            stageRenderer = go.GetComponent<Renderer>();
			stageRenderer.material = stageColorEnter;

            setLeaderboardHUD(stage, level, min, sec);
            
        }
    }

    public void OnPointerExit()
    {
        if (stageRenderer)
        {
			stageRenderer.material = stageColorExit;
            stageRenderer = null;
        }
        gazed = false;
        text.color = colorStart;
        hideLeaderboardHUD();
    }

    public void moveCameraTo(Vector3 destination)
    {
        Vector3 cameraPosition = cardboard.transform.position;
        destinationPrime = destination * 1.07f - cameraPosition * 0.07f;
        this.destination = destination;
        state = playerState.Moving;
        setAllGameObjectInactive();
    }

    public void setState(playerState st)
    {
        state = st;

        switch(state)
        {
            case playerState.MainMenu:
                mainMenu.SetActive(true);
                StartText.SetActive(true);
                SetText.SetActive(true);
                Credit.SetActive(true);
                HowText.SetActive(true);
                cardboard.GetComponent<Rotating>().enabled = true;
                break;

            case playerState.Credit:
                CreditMesh.SetActive(true);
                BackFromCredit.SetActive(true);
                break;

            case playerState.HowToPlay:
                Application.LoadLevel("Training");
                BackFromHowToPlay.SetActive(true);
                break;

            case playerState.Setting:
                SettingMesh.SetActive(true);
                BackFromSetting.SetActive(true);
                break;

		   case playerState.LevelSelect:
				levelSelectMenu.SetActive (true);
                break;

            case playerState.Level1:
                BackFromLevel1.SetActive(true);
                break;

            case playerState.Level2:
                BackFromLevel2.SetActive(true);
                break;

            case playerState.Level3:
                BackFromLevel3.SetActive(true);
                break;
        }
    }

    private void setAllGameObjectInactive()
    {
        BackFromCredit.SetActive(false);
        BackFromSetting.SetActive(false);
        BackFromHowToPlay.SetActive(false);
        mainMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        StartText.SetActive(false);
        SetText.SetActive(false);
        Credit.SetActive(false);
        HowText.SetActive(false);
        BackFromLevel1.SetActive(false);
        BackFromLevel2.SetActive(false);
        BackFromLevel3.SetActive(false);
        CreditMesh.SetActive(false);
        SettingMesh.SetActive(false);
        cardboard.GetComponent<Rotating>().enabled = false;
    }

    private void initDict()
    {
        PositionDict.Add("play game", levelSelect);
        StateDict.Add("play game", playerState.LevelSelect);

        PositionDict.Add("setting", setting);
        StateDict.Add("setting", playerState.Setting);

        PositionDict.Add("credit", credit);
        StateDict.Add("credit", playerState.Credit);

        PositionDict.Add("howtoplay", howToPlay);
        StateDict.Add("howtoplay", playerState.HowToPlay);

        PositionDict.Add("mainmenu", menuSelect);
        StateDict.Add("mainmenu", playerState.MainMenu);

        PositionDict.Add("level1", level1);
        StateDict.Add("level1", playerState.Level1);

        PositionDict.Add("level2", level2);
        StateDict.Add("level2", playerState.Level2);

        PositionDict.Add("level3", level3);
        StateDict.Add("level3", playerState.Level3);

    }

    public void setLanguage (string language)
    {
        if(language == "THAI")
        {
            textManager.EngToThai();
            PlayerPrefs.SetString("Language","THAI" );
            Application.LoadLevel(Application.loadedLevel);
        }
        if (language == "ENGLISH")
        {
            PlayerPrefs.SetString("Language", "ENGLISH");
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void initSetting()
    {
        string isThai = PlayerPrefs.GetString("Language");
        settingLanguageText.text = isThai;
        if (isThai == "")
        {
            settingLanguageText.text = "ENGLISH";
            PlayerPrefs.SetString("Language", "ENGLISH");
        }
        else if (isThai == "THAI")
            textManager.EngToThai();

        string isBGM = PlayerPrefs.GetString("BGM");
        if (isBGM == "")
            PlayerPrefs.SetString("BGM", "TRUE");
        else if (isBGM == "FALSE")
            bgmToggle.isOn = false;

        string isFX = PlayerPrefs.GetString("FX");
        if (isFX == "")
            PlayerPrefs.SetString("FX", "TRUE");
        else if (isFX == "FALSE")
            fxToggle.isOn = false;

        updateBGMMute();
    }

    public void updateBGMMute()
    {

        AudioSource audioSource = GetComponent<AudioSource>();
        Debug.Log("Test AudioSource: " + audioSource.mute);
        if (PlayerPrefs.GetString("BGM") == "FALSE")
            audioSource.mute = true;
        else
            audioSource.mute = false;
    }

    public void hideLeaderboardHUD()
    {
        BestTimeHUD.text = "";
        stageNameHUD.text = "";
        TimeHUD.text = "";
    }

    public void setLeaderboardHUD(int level, int stage, int min, int sec)
    {
        stageNameHUD.text = "Level: " + level + " Stage: " + stage;
        BestTimeHUD.text = "Best Time";
        if (min == -1 && sec == -1)
            TimeHUD.text = "No Record";
        else
            TimeHUD.text = "Min: " + min + " Sec: " + sec;
    }
}
