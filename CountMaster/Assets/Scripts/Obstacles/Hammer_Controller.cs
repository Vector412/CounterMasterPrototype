using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_Controller : MonoBehaviour, IObstacles
{
    
    public bool left = false;
    public bool right = false;

    Animator hammerController;

    private void Awake()
    {
        hammerController = GetComponentInChildren<Animator>();
       

    }

    private void Start()
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
    public void DestroyObjects(Collider col)
    {
        throw new System.NotImplementedException();
    }

    public void Moving()
    {
        throw new System.NotImplementedException();
    }

    
}
