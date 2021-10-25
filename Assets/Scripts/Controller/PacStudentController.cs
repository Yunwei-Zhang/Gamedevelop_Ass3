using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource collisionAudioSource;
    private Transform Pactransform;
    private Tweener Pactweener;
    private Vector3 PacEndPosition;
    private string lastInput;
    private string NextInput;
    private Animator animatorController;
    private bool UpdateOnce = false, UpdateOnce2 = true;
    private bool CompletePixel = true;
    private bool Walkable_D = true,Walkable_A = true,Walkable_S = true,Walkable_W = true;
    private GameObject[] Walls;
    // Start is called before the first frame update
    void Start()
    {
        //set paramaters
        this.Pactransform=gameObject.GetComponent<Transform>();
        this.Pactweener=gameObject.GetComponent<Tweener>();
        this.audioSource=GameObject.Find("/AudioSource/Pacman_Move_AudioSource").GetComponent<AudioSource>();
        this.collisionAudioSource=GameObject.Find("/AudioSource/Pacman_Collison").GetComponent<AudioSource>();
        this.animatorController = gameObject.GetComponent<Animator>();
        this.Walls = GameObject.FindGameObjectsWithTag("Wall");
        

        //rotate in clockwise
        // GameObject tempRotateTarget = new GameObject();
        // tempRotateTarget.GetComponent<Transform>().position = new Vector3 (-7,7.5f,10);
        // RotateTarget = tempRotateTarget.GetComponent<Transform>();

        //pass to tweener
        
    }

    // Update is called once per frame
    void Update()
    {
        //press when complete one pixel
        if(Input.GetKeyDown(KeyCode.D) && Walkable_D == true)
        {
            lastInput = "D";
            if(CompletePixel == true){
                ToRight();
            }
        }
        if(Input.GetKeyDown(KeyCode.A) && Walkable_A == true)
        {
            lastInput = "A";
            if(CompletePixel == true){
                ToLeft();
            }
        }
        if(Input.GetKeyDown(KeyCode.W) && Walkable_W == true)
        {
            lastInput = "W";
            if(CompletePixel == true){
                ToDown();
            }
        }
        if(Input.GetKeyDown(KeyCode.S) && Walkable_S == true)
        {
            lastInput = "S";
            if(CompletePixel == true){
                ToUp();
            }
        }

        //only for run moving audio once
        if(UpdateOnce){
          audioSource.Play();
          gameObject.GetComponent<ParticleSystem>().Play();
          UpdateOnce = false;
        }

        //complete one pixel
        if(Pactransform.position == PacEndPosition){
            audioSource.Pause();
            gameObject.GetComponent<ParticleSystem>().Stop();
            CompletePixel = true;
         }

         //check walls
         foreach (GameObject Wall in Walls){
             if(lastInput == "D"){
                 if(Wall.transform.position  == (Pactransform.position + new Vector3(1.0f,0f,0f)) ){
                    Walkable_D = false;
                    if(UpdateOnce2 == true){
                        collisionAudioSource.Play();
                        UpdateOnce2 = false;
                    }
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(-1.0f,0f,0f))){Walkable_A = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,-1.0f,0f))){Walkable_S = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,1.0f,0f))){ Walkable_W = false;}

                    animatorController.SetBool("TurnRight", true);
                    animatorController.SetBool("TurnLeft", false);
                    animatorController.SetBool("TurnUp", false);
                    animatorController.SetBool("TurnDown", false);
                }
             }
             if(lastInput == "A"){
                 if(Wall.transform.position  == (Pactransform.position + new Vector3(-1.0f,0f,0f)) ){
                    Walkable_A = false;
                    if(UpdateOnce2 == true){
                        collisionAudioSource.Play();
                        UpdateOnce2 = false;
                    }
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(1.0f,0f,0f))){Walkable_D = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,-1.0f,0f))){Walkable_S = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,1.0f,0f))){ Walkable_W = false;}

                    animatorController.SetBool("TurnLeft", true);
                    animatorController.SetBool("TurnRight", false);
                    animatorController.SetBool("TurnUp", false);
                    animatorController.SetBool("TurnDown", false);
                }
             }
             if(lastInput == "S"){
                 if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,-1.0f,0f)) ){
                    Walkable_S = false;
                    if(UpdateOnce2 == true){
                        collisionAudioSource.Play();
                        UpdateOnce2 = false;
                    }
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(1.0f,0f,0f))){Walkable_D = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(-1.0f,0f,0f))){Walkable_A = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,1.0f,0f))){ Walkable_W = false;}

                    animatorController.SetBool("TurnUp", true);
                    animatorController.SetBool("TurnRight", false);
                    animatorController.SetBool("TurnLeft", false);
                    animatorController.SetBool("TurnDown", false);
                }
             }
             if(lastInput == "W"){
                 if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,1.0f,0f)) ){
                    Walkable_W = false;
                    if(UpdateOnce2 == true){
                        collisionAudioSource.Play();
                        UpdateOnce2 = false;
                    }
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(1.0f,0f,0f))){Walkable_D = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(-1.0f,0f,0f))){Walkable_A = false;}
                    if(Wall.transform.position  == (Pactransform.position + new Vector3(0f,-1.0f,0f))){Walkable_S = false;}
             
                    animatorController.SetBool("TurnDown", true);
                    animatorController.SetBool("TurnRight", false);
                    animatorController.SetBool("TurnLeft", false);
                    animatorController.SetBool("TurnUp", false);
                }
             }
            }
         //oTeleporters
         if(Pactransform.position == new Vector3(-13.5f, 0.5f, 1f)){
             Pactransform.position = new Vector3(13.5f, 0.5f, 1f);
         }
         else if(Pactransform.position == new Vector3(13.5f, 0.5f, 1f)){
             Pactransform.position = new Vector3(-13.5f, 0.5f, 1f);
         }

         //when one pixel completed, go ahead for next pixel
         if(CompletePixel == true){
            

            // Transform testwallobject =  Pactransform;
            // if(lastInput == "D"){
            //     testwallobject.position = testwallobject.position+ new Vector3(1f,0f,0f);
            //     if(testwallobject.CompareTag("Wall")){Debug.Log("Stop");}
            // }

            if(lastInput == "D" && Walkable_D == true){ToRight();}
            if(lastInput == "A" && Walkable_A == true){ToLeft();}
            if(lastInput == "S" && Walkable_S == true){ToUp();}
            if(lastInput == "W" && Walkable_W == true){ToDown();}
         }


    }

    public void ToRight(){
        PacEndPosition = Pactransform.position + new Vector3(1f,0f,0f);
        animatorController.SetBool("TurnRight", true);
        animatorController.SetBool("TurnLeft", false);
        animatorController.SetBool("TurnUp", false);
        animatorController.SetBool("TurnDown", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.2f, audioSource);
        UpdateOnce = true;
        UpdateOnce2 = true;
        CompletePixel = false;
        Walkable_D = true;Walkable_A = true;Walkable_W = true;Walkable_S = true;
    }

    public void ToLeft(){
        PacEndPosition = Pactransform.position + new Vector3(-1f,0f,0f);
        animatorController.SetBool("TurnLeft", true);
        animatorController.SetBool("TurnRight", false);
        animatorController.SetBool("TurnUp", false);
        animatorController.SetBool("TurnDown", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.2f, audioSource);
        UpdateOnce = true;
        UpdateOnce2 = true;
        CompletePixel = false;
        Walkable_D = true;Walkable_A = true;Walkable_W = true;Walkable_S = true;
    }

    public void ToDown(){
        PacEndPosition = Pactransform.position + new Vector3(0f,1f,0f);
        animatorController.SetBool("TurnUp", true);
        animatorController.SetBool("TurnRight", false);
        animatorController.SetBool("TurnLeft", false);
        animatorController.SetBool("TurnDown", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.2f, audioSource);
        UpdateOnce = true;
        UpdateOnce2 = true;
        CompletePixel = false;
        Walkable_D = true;Walkable_A = true;Walkable_W = true;Walkable_S = true;
    }

    public void ToUp(){
        PacEndPosition = Pactransform.position + new Vector3(0f,-1f,0f);
        animatorController.SetBool("TurnDown", true);
        animatorController.SetBool("TurnRight", false);
        animatorController.SetBool("TurnLeft", false);
        animatorController.SetBool("TurnUp", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.2f, audioSource);
        UpdateOnce = true;
        UpdateOnce2 = true;
        CompletePixel = false;
        Walkable_D = true;Walkable_A = true;Walkable_W = true;Walkable_S = true;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("NormalPallet"))
        {
          Scorer.Score += 10.0f;
          Destroy(other.gameObject);
        }
         if(other.gameObject.CompareTag("Cherry")){
            Scorer.Score += 100.0f;
            Destroy(other.gameObject);
         }
    }
}
