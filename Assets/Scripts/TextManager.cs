using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

    public TextMesh[] engWord;

	
    public void EngToThai()
    {
        //a.text = Multilanguage.translateEngToThai(a.text);
        for (int i = 0; i < engWord.Length; i++)
        {
            if (engWord[i])
                engWord[i].text = Multilanguage.translateEngToThai(engWord[i].text.ToLower());
        }
    }

    public void LogAllEngWords()
    {
        for(int i=0; i<engWord.Length; i++)
        {
            if(engWord[i])
                Debug.Log("EW: " + engWord[i].text + " [i] : " + i);
        }
    }

}
