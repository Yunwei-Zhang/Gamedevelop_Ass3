using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Starter.EndGame == true){
            if(PlayerPrefs.GetInt("HighScoreState") <= (int)Scorer.Score){
                PlayerPrefs.SetString("minState", "" + Timer.Min);
                PlayerPrefs.SetString("secState", "" + Timer.Sec);
                PlayerPrefs.SetString("milState", "" + Timer.Mil);
                PlayerPrefs.SetInt("HighScoreState", (int)Scorer.Score);
                PlayerPrefs.Save();
            }   
        } 
    }
}
