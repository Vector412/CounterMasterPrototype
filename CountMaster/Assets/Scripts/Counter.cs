using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
   public int count;

   public event Action OnUpdatePlayers;
   
  
   public int Count { get; set; }

   private void Start()
   {
       Count = count;
       OnUpdatePlayers += Listener.Instance.Multiplayers;



   }

   private void OnTriggerEnter(Collider other)
   {
      Destroy(gameObject);
      OnUpdatePlayers?.Invoke();
     
   }
}
