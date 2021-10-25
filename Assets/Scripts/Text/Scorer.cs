using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    private Text Scoretext;
    public static float Score { set;get; }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Scoretext = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "" + Score;
    }
}
