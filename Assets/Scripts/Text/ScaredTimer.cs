using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaredTimer : MonoBehaviour
{
    private Text ScaredTimertext;
    public static bool startScared { set;get; }
    private float ScaredTimerCount = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        startScared = false;
        ScaredTimertext =  this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startScared == true){
            this.gameObject.SetActive(true);
            ScaredTimerCount -= Time.deltaTime;
            ScaredTimertext.text = "Scared Time: " + (int)ScaredTimerCount + ":" +  (int)((ScaredTimerCount%1)*100/1);
        }

        if(ScaredTimerCount <= 0){
            startScared = false;
            ScaredTimertext.text = "";
        }     
    }
}
