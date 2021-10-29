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
    private static bool endgame = false;
    public static bool EndGame { 
        set { endgame = value; }
        get { return endgame; }
    }
    private GameObject[] Lives;
    private GameObject[] Pallets_Normal;
    private GameObject[] Pallets_Special;

    // Start is called before the first frame update
    void Start()
    {
        Starttext = this.gameObject.GetComponent<Text>();
        Starttext.text = "3"; 
    }

    // Update is called once per frame
    void Update()
    {
        this.Lives = GameObject.FindGameObjectsWithTag("Live");
        this.Pallets_Normal = GameObject.FindGameObjectsWithTag("NormalPallet");
        this.Pallets_Special = GameObject.FindGameObjectsWithTag("PowerPallet");
        //game over
        if(Lives.Length == 0 || (Pallets_Normal.Length + Pallets_Special.Length) == 0){
            Debug.Log("Dead");
            Starttext.text = "Game Over";
            StartGame = false;
            EndGame = true;
        }
        StartTimer = Time.timeSinceLevelLoad;
        if(StartTimer >= 1.0f && Lives.Length != 0 && (Pallets_Normal.Length + Pallets_Special.Length) != 0){
            Starttext.text = "2";
        }
        if(StartTimer >= 2.0f && Lives.Length != 0 && (Pallets_Normal.Length + Pallets_Special.Length) != 0){
            Starttext.text = "1";
        }
        if(StartTimer >= 3.0f && Lives.Length != 0 && (Pallets_Normal.Length + Pallets_Special.Length) != 0){
            Starttext.text = "Go";
        }
        if(StartTimer >= 4.0f && Lives.Length != 0 && (Pallets_Normal.Length + Pallets_Special.Length) != 0){
            Starttext.text = "";
            StartGame = true;
        }
        
        
    }
}
