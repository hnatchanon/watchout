using UnityEngine;
using System.Collections;

public class Leaderboard {
    
	public static int[] getLeaderboard(int level, int stage)
    {
        string key = level + "_" + stage;
        if (PlayerPrefs.GetString(key) != "")
        {
            int[] bestTime = convertTimeStringToArray(PlayerPrefs.GetString(key));
            return bestTime;
        }
        return null;
    }

    public static void submitScore(int level, int stage, int min, int sec)
    {
        string key = level + "_" + stage;
        string value = min + "_" + sec;
        if (PlayerPrefs.GetString(key) != "")
        {
            int[] oldTime = convertTimeStringToArray(PlayerPrefs.GetString(key));
            if (oldTime[0] * 60 + oldTime[1] > min * 60 + sec)
            {
                PlayerPrefs.SetString(key, value);
            }
        }
        else
        {
            PlayerPrefs.SetString(key, value);
        }
        
 
    }
	
    private static int[] convertTimeStringToArray(string time)
    {
        int[] timeArray = new int[2];
        string[] stringArray = time.Split('_');
        timeArray[0] = int.Parse(stringArray[0]);
        timeArray[1] = int.Parse(stringArray[1]);
        return timeArray;
    }
    
}
