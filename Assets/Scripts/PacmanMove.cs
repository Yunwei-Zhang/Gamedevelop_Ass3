using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    private Transform RotateTarget;
    private AudioSource audioSource;
    private Transform Pactransform;
    private Tweener Pactweener;
    // Start is called before the first frame update
    void Start()
    {
        this.Pactransform=gameObject.GetComponent<Transform>();
        this.Pactweener=gameObject.GetComponent<Tweener>();
        this.audioSource=GameObject.Find("/AudioSource/Pacman_Move_AudioSource").GetComponent<AudioSource>();

        GameObject tempRotateTarget = new GameObject();
        tempRotateTarget.GetComponent<Transform>().position = new Vector3 (-7,7.5f,10);
        RotateTarget = tempRotateTarget.GetComponent<Transform>();

        Pactweener.AddTween(Pactransform, Pactransform.position, RotateTarget, audioSource, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
