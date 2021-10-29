using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Tweener Ghostweener;
    private Transform Ghosttransform;
    private Vector3 GhostEndPosition;
    private GameObject[] Walls;
    private string Lastwalk;
    private bool compeltepixel = true;
    private bool Walkable_D = true,Walkable_A = true,Walkable_S = true,Walkable_W = true;
    // Start is called before the first frame update
    void Start()
    {
        this.Ghosttransform = gameObject.GetComponent<Transform>();
        this.Ghostweener=gameObject.GetComponent<Tweener>();
        this.Walls = GameObject.FindGameObjectsWithTag("Wall");  
    }

    // Update is called once per frame
    void Update()
    {
        Ghosttransform = gameObject.transform;
        //check wakeable
         foreach (GameObject Wall in Walls){
             if(compeltepixel == true){
                 if(Wall.transform.position  == (Ghosttransform.position + new Vector3(1.0f,0f,0f))){
                     Walkable_D = false;
                 }
                 if(Wall.transform.position  == (Ghosttransform.position + new Vector3(-1.0f,0f,0f))){
                     Walkable_A = false;
                 }
                 if(Wall.transform.position  == (Ghosttransform.position + new Vector3(0f,1.0f,0f))){
                     Walkable_W = false;
                 }
                 if(Wall.transform.position  == (Ghosttransform.position + new Vector3(0f,-1.0f,0f))){
                     Walkable_S = false;
                 }
             }
         }
        
        if(compeltepixel == true && Starter.StartGame == true){
                Move();
                compeltepixel = false; 
                Walkable_D = true;Walkable_A = true;Walkable_W = true;Walkable_S = true;
        }

        if(Ghosttransform.position == GhostEndPosition){
            compeltepixel = true;
         }

    }

    private void Move(){
        
        if(Walkable_D){
                GhostEndPosition = gameObject.transform.position + new Vector3(1f,0f,0f);
                Ghostweener.AddTween(Ghosttransform, Ghosttransform.position, GhostEndPosition, 0.4f, null);
                //Lastwalk = "D";
            }
        else if(Walkable_A){
                GhostEndPosition = gameObject.transform.position + new Vector3(-1f,0f,0f);
                Ghostweener.AddTween(Ghosttransform, Ghosttransform.position, GhostEndPosition, 0.4f, null);
                //Lastwalk = "A";
            }
        else if(Walkable_W){
                GhostEndPosition = gameObject.transform.position + new Vector3(0f,1.0f,0f);
                Ghostweener.AddTween(Ghosttransform, Ghosttransform.position, GhostEndPosition, 0.4f, null);
               //Lastwalk = "W";
            }
        else if(Walkable_S){
                GhostEndPosition = gameObject.transform.position + new Vector3(0f,-1.0f,0f);
                Ghostweener.AddTween(Ghosttransform, Ghosttransform.position, GhostEndPosition, 0.4f, null); 
                //Lastwalk = "S"; 
            }
    }
}
