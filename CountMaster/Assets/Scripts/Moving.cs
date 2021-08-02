using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] Transform _target;
    public static float speed = 4;

    private delegate void Stop();
    private Stop stop;
    private IEnumerator coroutine;
    
    /*private void Awake()
    {
        coroutine = Running();
        stop = StopPlayer;
        StartCoroutine(coroutine);
    }
    
    private void StopPlayer()
    {
      StopCoroutine(coroutine);
    }*/

  /*private  IEnumerator Running()
    {
        var tiempoMov = 1.0f;
        var startTime = Time.deltaTime;
        while ((Time.deltaTime < startTime + tiempoMov))
        {
            float step  =  speed * Time.deltaTime;
            transform.Translate(Vector3.forward * step);
            yield return null;
        }
    }*/
}
