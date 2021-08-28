using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutManager : MonoBehaviour
{
    [SerializeField] private GameObject donut;

    private int currentCount;

    private void Start()
    {
        donut.transform.localScale = new Vector3(1f, 1f, 1f);
        EventManager.UpdateDonut += IncreaseDonut;
        EventManager.MinusPlayers += DecreaseDonut;
    }

    private void ChangeScaleDonut()
    {
        /*if (currentCount < 10)
        {
            donut.transform.localScale = new Vector3(1f, 1f, 1f);
        }*/

        if (currentCount < 15)
        {
            donut.transform.localScale = new Vector3(3.5f, 0, 3.5f);
        }

        if (currentCount > 15 && currentCount < 30)
        {
            donut.transform.localScale = new Vector3(5f, 0, 5f);
        }
        else if (currentCount > 30 && currentCount < 40)
        {
            donut.transform.localScale = new Vector3(6, 0, 6);
        }
        else if (currentCount > 40 && currentCount < 60)
        {
            donut.transform.localScale = new Vector3(6.5f, 0, 6.5f);
        }
    }

    private void IncreaseDonut(int count)
    {
        currentCount += count;
        ChangeScaleDonut();
    }

    private void DecreaseDonut()
    {
        currentCount--;
        ChangeScaleDonut();
    }


    private void OnDestroy()
    {
        EventManager.UpdateDonut -= IncreaseDonut;
        EventManager.MinusPlayers -= DecreaseDonut;
    }
}