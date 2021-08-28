using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private string _mainPlayer = "MainPlayer";
    public int count;
    
   public int Count { get; private  set; }

   private void Start()
   {
       Count = count;
      
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag(_mainPlayer))
       {
           Destroy(gameObject);
           EventManager.OnAddPlayer(count);
       }
       

     
     
   }
}
