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
            donut.transform.localScale = new Vector3(1.5f, 1f, 1.5f);
        }
        else if (count < 15)
        {
            donut.transform.localScale = new Vector3(2.1f, 1f, 2.1f);
        }

       else if (count > 15 && count < 30)
        {
            donut.transform.localScale = new Vector3(3.1f, 1f, 3.1f);
        }
        else if (count > 30 && count < 40)
        {
            donut.transform.localScale = new Vector3(3.7f, 1f, 3.7f);
        }
        else if (count > 40 && count < 60)
        {
            donut.transform.localScale = new Vector3(4.1f, 1f, 4.1f);
        }
    }

    private void OnDestroy()
    {
        EventManager.CheckScaleDonut -= ChangeScaleDonut;
    }
}