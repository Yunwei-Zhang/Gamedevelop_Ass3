using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject Level1;
    // Start is called before the first frame update
    void Awake()
    {
        Level1 = GameObject.Find("Level1Layout");
        
        //colon the left-bottom/right-top/right/bottom maps
        Instantiate(Level1,new Vector3(0, 1, 1), Quaternion.Euler(new Vector3(0, 180, -180)));
        Instantiate(Level1,new Vector3(0, 1, 1), Quaternion.Euler(new Vector3(0, 0, -180)));
        Instantiate(Level1,new Vector3(0, 0, 1), Quaternion.Euler(new Vector3(0, 180, 0)));

        //colon the destroyed pallets
        Instantiate(GameObject.FindWithTag("NormalPallet"),new Vector3(-7.5f,0.5f,0) ,Quaternion.identity);
        Instantiate(GameObject.FindWithTag("NormalPallet"),new Vector3(7.5f,0.5f,0) ,Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the overlapped pallet
        Destroy(GameObject.Find("Pallet_Normal (0)"));
    }
}
