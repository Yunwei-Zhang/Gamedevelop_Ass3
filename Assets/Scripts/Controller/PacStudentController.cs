using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private AudioSource audioSource;
    private Transform Pactransform;
    private Tweener Pactweener;
    private Vector3 PacEndPosition;
    private string lastInput;
    private string NextInput;
    private Animator animatorController;
    private bool UpdateOnce = false;
    private bool CompletePixel = true;
    private GameObject[] NormalPallets;
    // Start is called before the first frame update
    void Start()
    {
        //set paramaters
        this.Pactransform=gameObject.GetComponent<Transform>();
        this.Pactweener=gameObject.GetComponent<Tweener>();
        this.audioSource=GameObject.Find("/AudioSource/Pacman_Move_AudioSource").GetComponent<AudioSource>();
        this.animatorController = gameObject.GetComponent<Animator>();

        this.NormalPallets = GameObject.FindGameObjectsWithTag("NormalPallet");
        

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
        if(Input.GetKeyDown(KeyCode.D))
        {
            lastInput = "D";
            if(CompletePixel == true){
                ToRight();
            }
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            lastInput = "A";
            if(CompletePixel == true){
                ToLeft();
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            lastInput = "W";
            if(CompletePixel == true){
                ToDown();
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
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
            gameObject.GetComponent<ParticleSystem>().Pause();
            CompletePixel = true;
         }

        //  foreach (GameObject Wall in Walls){
        //         if((Wall.transform.position + new Vector3 (-4f,10f,0f)) == Pactransform.position ){
        //             Debug.Log("Sorry");
        //         }
        //     }

         //when one pixel completed, go ahead for next pixel
         if(CompletePixel == true){
            

            // Transform testwallobject =  Pactransform;
            // if(lastInput == "D"){
            //     testwallobject.position = testwallobject.position+ new Vector3(1f,0f,0f);
            //     if(testwallobject.CompareTag("Wall")){Debug.Log("Stop");}
            // }

            if(lastInput == "D"){ToRight();}
            if(lastInput == "A"){ToLeft();}
            if(lastInput == "S"){ToUp();}
            if(lastInput == "W"){ToDown();}
         }


    }

    public void ToRight(){
        PacEndPosition = Pactransform.position + new Vector3(1f,0f,0f);
        animatorController.SetBool("TurnRight", true);
        animatorController.SetBool("TurnLeft", false);
        animatorController.SetBool("TurnUp", false);
        animatorController.SetBool("TurnDown", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.5f, audioSource);
        UpdateOnce = true;
        CompletePixel = false;
    }

    public void ToLeft(){
        PacEndPosition = Pactransform.position + new Vector3(-1f,0f,0f);
        animatorController.SetBool("TurnLeft", true);
        animatorController.SetBool("TurnRight", false);
        animatorController.SetBool("TurnUp", false);
        animatorController.SetBool("TurnDown", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.5f, audioSource);
        UpdateOnce = true;
        CompletePixel = false;
    }

    public void ToDown(){
        PacEndPosition = Pactransform.position + new Vector3(0f,1f,0f);
        animatorController.SetBool("TurnUp", true);
        animatorController.SetBool("TurnRight", false);
        animatorController.SetBool("TurnLeft", false);
        animatorController.SetBool("TurnDown", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.5f, audioSource);
        UpdateOnce = true;
        CompletePixel = false;
    }

    public void ToUp(){
        PacEndPosition = Pactransform.position + new Vector3(0f,-1f,0f);
        animatorController.SetBool("TurnDown", true);
        animatorController.SetBool("TurnRight", false);
        animatorController.SetBool("TurnLeft", false);
        animatorController.SetBool("TurnUp", false);
        Pactweener.AddTween(Pactransform, Pactransform.position, PacEndPosition, 0.5f, audioSource);
        UpdateOnce = true;
        CompletePixel = false;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("NormalPallet"))
        {
          Scorer.Score += 10.0f;
          Destroy(other.gameObject);
        }
    }
}
