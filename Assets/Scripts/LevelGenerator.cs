using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject Level1;
    public static bool back1Toback2 { set;get; }
    private AudioSource back1audioSource;
    private AudioSource back2audioSource;
    private bool AudioUpdateOnce = true;
    // Start is called before the first frame update
    void Awake()
    {
        Level1 = GameObject.Find("Level1Layout");
        back1Toback2 = false;
        
        //colon the left-bottom/right-top/right/bottom maps
        Instantiate(Level1,new Vector3(0, 1, 1), Quaternion.Euler(new Vector3(0, 180, -180)));
        Instantiate(Level1,new Vector3(0, 1, 1), Quaternion.Euler(new Vector3(0, 0, -180)));
        Instantiate(Level1,new Vector3(0, 0, 1), Quaternion.Euler(new Vector3(0, 180, 0)));

        //colon the destroyed pallets
        Instantiate(GameObject.FindWithTag("NormalPallet"),new Vector3(-7.5f,0.5f,1f) ,Quaternion.identity);
        Instantiate(GameObject.FindWithTag("NormalPallet"),new Vector3(7.5f,0.5f,1f) ,Quaternion.identity);

        this.back1audioSource=GameObject.Find("/AudioSource/Background_1").GetComponent<AudioSource>();
        this.back2audioSource=GameObject.Find("/AudioSource/Background_2").GetComponent<AudioSource>();
        back1audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the overlapped pallet
        Destroy(GameObject.Find("Pallet_Normal (0)"));

        if(back1Toback2 == true){
            back1audioSource.Stop();
            if(AudioUpdateOnce == true){
                back2audioSource.Play();
                AudioUpdateOnce = false;
            }
        }
    }
}
