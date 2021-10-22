using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { set;get;  }
    public Vector3 StartPos { set;get; }
    public AudioSource TargetaudioSource { set;get; }
    public float StartTime { set;get; }
    public float Duration { set;get;  }

    public Tween(){}

    public Tween(Transform target ,Vector3 startPos,AudioSource targetaudioSource , float startTime ,float duration){
      this.Target = target;
      this.StartPos = startPos;
      this.TargetaudioSource = targetaudioSource;
      this.StartTime = startTime;
      this.Duration = duration;
    }
}
