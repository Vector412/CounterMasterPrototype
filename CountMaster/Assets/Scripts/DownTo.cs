using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTo : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
       
    }

    public void OnCollisionExit(Collision other)
    {
       var b =  gameObject.GetComponent<Rigidbody>();
       b.drag = 0;
       Debug.Log(b.drag);
    }
}
