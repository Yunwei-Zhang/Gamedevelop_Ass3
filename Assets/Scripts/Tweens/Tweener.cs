using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween tween;
    // private bool UpdateOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(tween != null){
        float movepersecond = (Time.time-this.tween.StartTime)/this.tween.Duration;
        this.tween.PacStudent.position = Vector3.Lerp(tween.StartPos, tween.EndPos, movepersecond);

        // if(UpdateOnce){
        //   tween.TargetaudioSource.Play();
        //   UpdateOnce = false;
        // }
        // if(this.tween.PacStudent.position == tween.EndPos){
        //   tween.TargetaudioSource.Pause();
        // }
      }   
    }

    public void AddTween(Transform pacStudent, Vector3 startPos, Vector3 endpos, float duration, AudioSource targetaudioSource){
      // if(this.tween == null){
        tween = new Tween(pacStudent, startPos, endpos, Time.time, duration, targetaudioSource);
        // UpdateOnce = true;
      // }
    }
}
