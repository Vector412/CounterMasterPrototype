using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
  
  // public  static event Action OnUpdateDonut;
   public static event Action OnGameEnd;
   public static event Action<int,bool> UpdatePlayerCount;



   public static void GameEnd()
   {
         OnGameEnd?.Invoke();
   }
   

   public static void OnUpdatePlayerCount(int count,bool IsIncrease)
   {
         UpdatePlayerCount?.Invoke(count,IsIncrease);
   }
}
