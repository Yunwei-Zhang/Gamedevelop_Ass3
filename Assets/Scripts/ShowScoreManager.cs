using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreManager : MonoBehaviour
{
    private Text highestScore;
    private Text hishestScoreTimer;
    // Start is called before the first frame update
    void Start()
    { 
        Debug.Log(PlayerPrefs.GetInt("HighScoreState"));
        this.highestScore=GameObject.Find("/Canvas/HighScoreNumber").GetComponent<Text>();
        this.hishestScoreTimer=GameObject.Find("/Canvas/HighScoreTimer").GetComponent<Text>();
        highestScore.text = "" + PlayerPrefs.GetInt("HighScoreState");
        hishestScoreTimer.text = PlayerPrefs.GetString("minState") + ":" + PlayerPrefs.GetString("secState") + ":" + PlayerPrefs.GetString("milState");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
