using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviourSingleton<Listener>
{
  
   private event Action OnUpdateDonut;
   private event Action OnUpdatePlayer;

   private void Start()
   {
      SpawnObject spawnObject = FindObjectOfType<SpawnObject>();
      
      OnUpdateDonut += spawnObject.CheckScaleDonut;
      OnUpdatePlayer += spawnObject.CreatePlayers;

   }
   
   public void KillPlayers()
   {
      Debug.Log("Killed");
      if (OnUpdateDonut != null)
      {
         Debug.Log("Call check donut");
         OnUpdateDonut.Invoke();
      }
   }

   public void Multiplayers()
   {
      Debug.Log("Multiplayer");
      if (OnUpdatePlayer != null)
      {
         OnUpdatePlayer?.Invoke();
      }
   }








}
