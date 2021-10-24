using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    private float Timer = 0f;
    private float createTime = 10.0f;
    private GameObject tempCherry;
    private Vector3 CherryStartPos;
    private float CherryStartTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= createTime){
            tempCherry = Instantiate(this.gameObject,new Vector3(Random.Range(-12.5f, 12.5f), 15f, 1), Quaternion.identity);
            CherryStartPos = tempCherry.transform.position;
            CherryStartTime = Time.time;
            createTime += 10.0f;       
        }
        Timer+=Time.deltaTime; 
        if(tempCherry!= null){
            float cherryspeed = (Time.time-CherryStartTime)/10.0f; 
            tempCherry.transform.position = Vector3.Lerp(CherryStartPos, CherryStartPos + new Vector3 (0,-30f,0), cherryspeed);

            if(tempCherry.transform.position.y <= -14.9){
                Destroy(tempCherry);
            }
        }
        
    }
}
