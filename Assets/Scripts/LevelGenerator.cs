using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject Level1;
    public static bool back1Toback2 { set;get; }
    public static bool back2Toghostdead { set;get; }
    private AudioSource back1audioSource;
    private AudioSource back2audioSource;
    private AudioSource ghostdeadaudioSource;
    public static bool AudioUpdateOnce { set;get; }
    public static bool AudioUpdateOnce2 { set;get; }
    public static bool AudioUpdateOnce3 { set;get; }
    // Start is called before the first frame update
    void Awake()
    {
        Level1 = GameObject.Find("Level1Layout");
        back1Toback2 = false;
        back2Toghostdead = false;
        AudioUpdateOnce = true;
        AudioUpdateOnce2 = true;
        AudioUpdateOnce3 = true;
        
        //colon the left-bottom/right-top/right/bottom maps
        Instantiate(Level1,new Vector3(0, 1, 1), Quaternion.Euler(new Vector3(0, 180, -180)));
        Instantiate(Level1,new Vector3(0, 1, 1), Quaternion.Euler(new Vector3(0, 0, -180)));
        Instantiate(Level1,new Vector3(0, 0, 1), Quaternion.Euler(new Vector3(0, 180, 0)));

        //colon the destroyed pallets
        Instantiate(GameObject.FindWithTag("NormalPallet"),new Vector3(-7.5f,0.5f,1f) ,Quaternion.identity);
        Instantiate(GameObject.FindWithTag("NormalPallet"),new Vector3(7.5f,0.5f,1f) ,Quaternion.identity);

        this.back1audioSource=GameObject.Find("/AudioSource/Background_1").GetComponent<AudioSource>();
        this.back2audioSource=GameObject.Find("/AudioSource/Background_2").GetComponent<AudioSource>();
        this.ghostdeadaudioSource=GameObject.Find("/AudioSource/Ghost_Dead").GetComponent<AudioSource>();
        ghostdeadaudioSource.time = 47.0f;

        //Back1audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the overlapped pallet
        Destroy(GameObject.Find("Pallet_Normal (0)"));

        //pause back1, start back2
        if(back1Toback2 == true && AudioUpdateOnce == true){
            Debug.Log("1");
            back1audioSource.Pause();
            back2audioSource.Play();
            AudioUpdateOnce = false;
        }

        //when back2 stop, start back1
        if(ScaredTimer.startScared == false && AudioUpdateOnce2 == true && Starter.StartGame == true){
            back2audioSource.Stop();
            back1audioSource.Play();
            AudioUpdateOnce2 = false;
            back1Toback2 = false;
        }

        if(back2Toghostdead == true){
            ghostdeadaudioSource.Play();
            back2Toghostdead = false;
        }

        if(ghostdeadaudioSource.time >= 49.0f){
            ghostdeadaudioSource.Stop();
        }
    }
}
