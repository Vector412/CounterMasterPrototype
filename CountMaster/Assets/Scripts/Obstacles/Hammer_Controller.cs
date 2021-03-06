using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_Controller : MonoBehaviour, IObstacles
{
    
    public bool left = false;
    public bool right = false;
    
    private string mainPlayer = "MainPlayer";

    Animator hammerController;

    private void Awake()
    {
        hammerController = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
      Moving();
    }
    public void DestroyObjects(Collider col)
    {
      
    }

    public void Moving()
    {
        if (left && !right)
        {
            hammerController.SetBool("Left", true);
            hammerController.SetBool("Right", false);
        }

        if (right && !left)
        {
            hammerController.SetBool("Left", false);
            hammerController.SetBool("Right", true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (gameObject && !other.CompareTag(mainPlayer))
            {
                Destroy(other.gameObject);
                EventManager.OnUpdateCountPlayers(1, false);
            }
    }
}
