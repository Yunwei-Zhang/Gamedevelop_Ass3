using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public Transform RotateTarget;
    public AudioSource audioSource;
    private Transform Pactransform;
    private Tweener Pactweener;
    // Start is called before the first frame update
    void Start()
    {
        this.Pactransform=gameObject.GetComponent<Transform>();
        this.Pactweener=gameObject.GetComponent<Tweener>();
        Pactweener.AddTween(Pactransform, Pactransform.position, RotateTarget, audioSource, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
