using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform PacStudent { set;get;  }
    public Vector3 StartPos { set;get; }
    public Vector3 EndPos { set;get; }
    public AudioSource TargetaudioSource { set;get; }
    public float StartTime { set;get; }
    public float Duration { set;get;  }

    public Tween(){}

    public Tween(Transform pacStudent ,Vector3 startPos, Vector3 endPos, float startTime ,float duration, AudioSource targetaudioSource){
      this.PacStudent = pacStudent;
      this.StartPos = startPos;
      this.EndPos = endPos;
      this.TargetaudioSource = targetaudioSource;
      this.StartTime = startTime;
      this.Duration = duration;
    }
}
