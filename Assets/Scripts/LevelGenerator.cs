using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject Level1;
    // Start is called before the first frame update
    void Start()
    {
        Level1 = GameObject.Find("Level1Layout");
        Instantiate(Level1,new Vector3(0, 0, 1), Quaternion.Euler(new Vector3(0, 180, -180)));
        Instantiate(Level1,new Vector3(0, 0, 1), Quaternion.Euler(new Vector3(0, 0, -180)));
        Instantiate(Level1,new Vector3(0, 0, 1), Quaternion.Euler(new Vector3(0, 180, 0)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
