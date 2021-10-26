using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    private Text Starttext;
    private float StartTimer = 0.0f;
    private static bool startgame = false;
    public static bool StartGame { 
        set { startgame = value; }
        get { return startgame; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Starttext = this.gameObject.GetComponent<Text>();
        Starttext.text = "3"; 
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer = Time.timeSinceLevelLoad;
        if(StartTimer >= 1.0f){
            Starttext.text = "2";
        }
        if(StartTimer >= 2.0f){
            Starttext.text = "1";
        }
        if(StartTimer >= 3.0f){
            Starttext.text = "Go";
        }
        if(StartTimer >= 4.0f){
            Starttext.text = "";
            StartGame = true;
        }
        
    }
}
