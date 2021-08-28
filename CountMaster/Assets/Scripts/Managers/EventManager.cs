using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
  
  // public  static event Action OnUpdateDonut;
   public static event Action OnGameEnd;
   public static event Action<int> UpdateDonut;
   public static event Action<int> AddPlayers;
   public static event Action MinusPlayers;
   
   
   
   public static void GameEnd()
   {
         OnGameEnd?.Invoke();
   }
   
   public static void OnAddPlayer(int count)
   {
         AddPlayers?.Invoke(count);
         OnUpdateDonut(count);
   }
   
   public static void OnMinusPlayers()
   {
         MinusPlayers?.Invoke();
   }

   public static void OnUpdateDonut(int count)
   {
         UpdateDonut?.Invoke(count);
   }
}
