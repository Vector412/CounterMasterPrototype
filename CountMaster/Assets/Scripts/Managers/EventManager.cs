using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
  
  // public  static event Action OnUpdateDonut;
   public static event Action OnGameEnd;
   public static event Action<int> SpawnPlayers;
   public static event Func<Friendly, bool> CollisionPLayer;
   public static event Action<Friendly> SpawnFriendlyPlayers;

   public static event Action<bool> SendAnswerAboutCollision;
   
   
   public static event Action<int, bool> UpdateCountPlayers;
   
   
   
   public static event Action<int> CheckScaleDonut;



   public static void GameEnd()
   {
         OnGameEnd?.Invoke();
   }
   

   public static void OnSpawnPlayers(int count)
   {
         SpawnPlayers?.Invoke(count);
   }
   
   public static void OnUpdateCountPlayers(int count, bool isIncrease)
   {
         UpdateCountPlayers?.Invoke(count, isIncrease);
   }
   
   public static void OnCheckScaleDonut(int countPlayers)
   {
         CheckScaleDonut?.Invoke(countPlayers);
   }

   public static void OnSpawnFriendlyPlayers(Friendly obj)
   {
         SpawnFriendlyPlayers?.Invoke(obj);
   }

   public static void OnCollisionPLayer(Friendly obj)
   {
         CollisionPLayer?.Invoke(obj);
   }

   public static void OnSendAnswerAboutCollision(bool obj)
   {
         SendAnswerAboutCollision?.Invoke(obj);
   }
}
