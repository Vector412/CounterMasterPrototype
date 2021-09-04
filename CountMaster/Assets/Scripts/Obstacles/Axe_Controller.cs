using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Axe_Controller : MonoBehaviour, IObstacles
{
    public GameObject axe_handle;
    private string mainPlayer = "MainPlayer";
  
  

    void Update()
    {
        Moving();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject && !other.CompareTag(mainPlayer))
        {
            Destroy(other.gameObject);
            EventManager.OnUpdateCountPlayers(1, false);
           
        }
    }
    
    public void Moving()
    {
        float angle = Mathf.Sin(Time.time*2) * 90; //tweak this to change frequency

        axe_handle.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);

        
    }
}