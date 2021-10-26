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
    private Animator Ghost1Controller,Ghost2Controller,Ghost3Controller,Ghost4Controller;
    private bool UpdateOnce = false, UpdateOnce2 = true;
    private bool CompletePixel = true;
    private bool PacDead = false;
    private bool Walkable_D = true,Walkable_A = true,Walkable_S = true,Walkable_W = true;
    private GameObject deadghost;
    private GameObject[] Walls;
    private GameObject[] Lives;
    // Start is called before the first frame update
    void Start()
    {
        //set paramaters
        this.Pactransform=gameObject.GetComponent<Transform>();
        this.Pactweener=gameObject.GetComponent<Tweener>();
        this.audioSource=GameObject.Find("/AudioSource/Pacman_Move_AudioSource").GetComponent<AudioSource>();
        this.collisionAudioSource=GameObject.Find("/AudioSource/Pacman_Collison").GetComponent<AudioSource>();
        this.animatorController = gameObject.GetComponent<Animator>();
        this.Ghost1Controller = GameObject.Find("/Ghosts/Ghost1_Normal").GetComponent<Animator>();
        this.Ghost2Controller = GameObject.Find("/Ghosts/Ghost2_Normal").GetComponent<Animator>();
        this.Ghost3Controller = GameObject.Find("/Ghosts/Ghost3_Normal").GetComponent<Animator>();
        this.Ghost4Controller = GameObject.Find("/Ghosts/Ghost4_Normal").GetComponent<Animator>();
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
        this.Lives = GameObject.FindGameObjectsWithTag("Live");
        //press when complete one pixel
        if(Input.GetKeyDown(KeyCode.D) && Walkable_D == true && PacDead == false && Starter.StartGame == true)
        {
            lastInput = "D";
            if(CompletePixel == true){
                ToRight();
            }
        }
        if(Input.GetKeyDown(KeyCode.A) && Walkable_A == true && PacDead == false && Starter.StartGame == true)
        {
            lastInput = "A";
            if(CompletePixel == true){
                ToLeft();
            }
        }
        if(Input.GetKeyDown(KeyCode.W) && Walkable_W == true && PacDead == false && Starter.StartGame == true)
        {
            lastInput = "W";
            if(CompletePixel == true){
                ToDown();
            }
        }
        if(Input.GetKeyDown(KeyCode.S) && Walkable_S == true && PacDead == false && Starter.StartGame == true)
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

            if(lastInput == "D" && Walkable_D == true && PacDead == false){ToRight();}
            if(lastInput == "A" && Walkable_A == true && PacDead == false){ToLeft();}
            if(lastInput == "S" && Walkable_S == true && PacDead == false){ToUp();}
            if(lastInput == "W" && Walkable_W == true && PacDead == false){ToDown();}
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

    public void DieFunction(){
        Instantiate(this.gameObject,new Vector3(-12.5f, 13.5f, 1f), Quaternion.identity);
        Destroy(this.gameObject);
        PacDead = false;
        animatorController.SetBool("TurnDie", false);
    }

    IEnumerator GhostDeadFunction(GameObject g){
        
        yield return new WaitForSeconds(5.0f);
        g.GetComponent<Animator>().SetTrigger("TurnWalking");
        //Destroy(g);
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
        if(other.gameObject.CompareTag("PowerPallet")){
          Ghost1Controller.SetTrigger("TurnScared");
          Ghost2Controller.SetTrigger("TurnScared");
          Ghost3Controller.SetTrigger("TurnScared");
          Ghost4Controller.SetTrigger("TurnScared");
          LevelGenerator.back1Toback2 = true;
          LevelGenerator.AudioUpdateOnce = true;
          ScaredTimer.startScared = true;
          Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Ghost") && ScaredTimer.startScared == true){
            other.GetComponent<Animator>().SetTrigger("TurnDead");
            Scorer.Score += 300.0f;
            //deadghost = other.gameObject;
            //Destroy(other.gameObject);
            LevelGenerator.back2Toghostdead = true;
            StartCoroutine(GhostDeadFunction(other.gameObject));
            //Invoke("GhostDeadFunction", 2.0f);
        }
        if(other.gameObject.CompareTag("Ghost") && ScaredTimer.startScared == false){
          PacDead = true;
          animatorController.SetBool("TurnDie", true);
          if(Lives.Length == 3){Destroy (GameObject.Find("/HUD/Lives/Live3"));}
          if(Lives.Length == 2){Destroy (GameObject.Find("/HUD/Lives/Live2"));}
          if(Lives.Length == 1){Destroy (GameObject.Find("/HUD/Lives/Live1"));}
          Invoke("DieFunction", 2.7f);
        }
    }
}
