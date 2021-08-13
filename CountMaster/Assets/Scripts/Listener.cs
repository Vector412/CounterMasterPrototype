using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviourSingleton<Listener>
{
  
   private event Action OnUpdateDonut;
   private event Action OnGameOver;
   private event Action<int> OnUpdatePlayer;

   private void Start()
   {
      SpawnObject spawnObject = FindObjectOfType<SpawnObject>();
      Dead dead = FindObjectOfType<Dead>();
      
      OnUpdateDonut += spawnObject.CheckScaleDonut;
      OnUpdatePlayer += spawnObject.CreatePlayers;
      OnGameOver += dead.GameOver;

   }
   
   public void KillPlayers()
   {
      if (OnUpdateDonut != null)
      {
         OnUpdateDonut.Invoke();
      }
   }

   public void Multiplayers(int count)
   {
      if (OnUpdatePlayer != null)
      {
         OnUpdatePlayer?.Invoke(count);
      }
   }

   public void GameEnd()
   {
      if (OnGameOver != null)
      {
         OnGameOver?.Invoke();
      }
   }








}
