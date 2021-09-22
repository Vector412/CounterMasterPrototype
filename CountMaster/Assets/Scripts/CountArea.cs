using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountArea : MonoBehaviour
{
    [SerializeField] private GameObject pointOnBoard;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject donut;

    private float _radiusPlayer;
    private int players = 1;
    private float startRadiusDonut;

    private void Awake()
    {
        DontDestroyOnLoad(donut.gameObject);
    }

    private void Start()
    {
        EventManager.UpdateCountPlayers += CountPlayerInDonut;


        var capsulePlayer = player.GetComponent<CapsuleCollider>();
        _radiusPlayer = capsulePlayer.radius;
        donut.transform.localScale = Vector3.one;
        startRadiusDonut = Vector3.Distance(pointOnBoard.transform.position, player.transform.position);
        Debug.Log(startRadiusDonut);
    }


    private void CountPlayerInDonut(int count, bool isIncrease)
    {
        if (isIncrease)
        {
            players += count;
        }
        else
        {
            players -= count;
        }
        
        ChangeScaleDonut(players, isIncrease);
    }

    private void ChangeScaleDonut(int count, bool isIncrease)
    {
        var radiusDonutMulti = (float) ((_radiusPlayer * _radiusPlayer * count) / 0.6);
        var radiusDonut = (Mathf.Sqrt(radiusDonutMulti));

        var difference = radiusDonut - startRadiusDonut;
        startRadiusDonut = radiusDonut;
        Debug.Log(startRadiusDonut);
       
     
        var localScale = donut.transform.localScale;


        donut.transform.localScale = new Vector3(localScale.x + difference, 1, localScale.z + difference);
        Debug.Log(donut.transform.localScale);


        // donut.transform.localScale = localScale;
    }
}