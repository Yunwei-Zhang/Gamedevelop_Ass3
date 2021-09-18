using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween tween;
    private bool UpdateOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(tween!=null){ 
            tween.Target.RotateAround(tween.RotateTarget.position, -tween.Target.forward, 0.3f);
            if(UpdateOnce){
                tween.TargetaudioSource.Play();
                UpdateOnce = false;
            }
        }
    }

    public void AddTween(Transform target, Vector3 startPos, Transform rotateTarget, AudioSource targetaudioSource, float duration){
      if(this.tween == null){
        tween = new Tween(target, startPos, rotateTarget, targetaudioSource, Time.time, duration);
      }
    }
}
