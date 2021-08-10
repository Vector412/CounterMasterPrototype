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
      if (OnUpdateDonut != null)
      {
         OnUpdateDonut.Invoke();
      }
   }

   public void Multiplayers()
   {
      if (OnUpdatePlayer != null)
      {
         OnUpdatePlayer?.Invoke();
      }
   }








}
