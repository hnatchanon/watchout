using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Multilanguage : MonoBehaviour {


    private static Dictionary<string, string> dict = new Dictionary<string, string>();

    void Start()
    {
        dict.Add("credit", "เครดิต");
        dict.Add("back to menu", "กลับสู่เมนู");
        dict.Add("level select", "เลือกด่าน");
        dict.Add("start game", "เริ่มเกม");
        dict.Add("training", "ฝึกหัด");
        dict.Add("setting", "ตั้งค่า");
    }

    public static string translateEngToThai(string engWord)
    {
        if(dict.ContainsKey(engWord))
            return dict[engWord.ToLower()];
        return engWord;
    }
}
