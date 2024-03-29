using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text Timertext;
    private static int min = 0, sec = 0, mil = 0;
    public static int Min { get { return min; }}
    public static int Sec { get { return sec; }}
    public static int Mil { get { return mil; }}
    private string minprint, secprint, milprint;
    // Start is called before the first frame update
    void Start()
    {
        Timertext =  this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //set the game timer to ensure the format correct
        var temptime = Time.timeSinceLevelLoad - 4.0f;
        if(temptime >= 0.0f && Starter.StartGame == true){
        min = (int)temptime/60;
        sec = (int)(temptime%60)/1;
        mil = (int)(((temptime%60) - sec)*100)/1;
        var i = (min>10)?(minprint = "" + min):(minprint = "0"+ min);
        var ii = (sec>10)?(secprint = "" + sec):(secprint = "0"+ sec);
        var iii = (mil>10)?(milprint = "" + mil):(milprint = "0"+ mil);
        Timertext.text = minprint + ":" + secprint + ":" + milprint;
        }
    }
}
