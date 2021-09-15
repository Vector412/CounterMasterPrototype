using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CountPlayers
{
    public static int countPlayers = 1;

    public static void UpdateCount(int count)
    {
        countPlayers += count;
        Debug.Log(countPlayers);
    }

}



public class CountPlayerManager : MonoBehaviour
{
    private int _currentCountPlayer = 1;
     
     void Start()
    {
        EventManager.OnGameEnd += RestartCount;
        EventManager.UpdateCountPlayers += UpdateCountPlayers;
    }

    private void UpdateCountPlayers(int count, bool isIncrease)
    {
        if (isIncrease)
        {
          //  CountPlayers.UpdateCount(count);
            CountPlayers.countPlayers += count;
            EventManager.OnCheckScaleDonut( CountPlayers.countPlayers /*count*/ );
        }
        else
        {
           // CountPlayers.UpdateCount(-count);
            CountPlayers.countPlayers  -= count;
            EventManager.OnCheckScaleDonut( CountPlayers.countPlayers /*count*/ );
        }
    }

    private void RestartCount()
    {
        CountPlayers.countPlayers  = 1;
    }

    private void OnDestroy()
    {
        EventManager.OnGameEnd -= RestartCount;
        EventManager.UpdateCountPlayers -= UpdateCountPlayers;
    }
}
