using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private string _mainPlayer = "MainPlayer";
    public int count;
    
   public event Action<int> OnUpdatePlayers;
   
  
   public int Count { get; set; }

   private void Start()
   {
       Count = count;
       OnUpdatePlayers += Listener.Instance.Multiplayers;
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag(_mainPlayer))
       {
           Destroy(gameObject);
           OnUpdatePlayers?.Invoke(count);
       }
       

     
     
   }
}
