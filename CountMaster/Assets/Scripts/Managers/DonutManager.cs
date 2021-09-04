using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutManager : MonoBehaviour
{
    [SerializeField] private GameObject donut;
    

    private void Start()
    {
        donut.transform.localScale = new Vector3(1f, 1f, 1f);
        EventManager.CheckScaleDonut += ChangeScaleDonut;
    }

    private void ChangeScaleDonut(int count)
    {
        if (count < 10)
        {
            donut.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if (count < 15)
        {
            donut.transform.localScale = new Vector3(3.5f, 0, 3.5f);
        }

       else if (count > 15 && count < 30)
        {
            donut.transform.localScale = new Vector3(5f, 0, 5f);
        }
        else if (count > 30 && count < 40)
        {
            donut.transform.localScale = new Vector3(6, 0, 6);
        }
        else if (count > 40 && count < 60)
        {
            donut.transform.localScale = new Vector3(6.5f, 0, 6.5f);
        }
    }

    private void OnDestroy()
    {
        EventManager.CheckScaleDonut -= ChangeScaleDonut;
    }
}