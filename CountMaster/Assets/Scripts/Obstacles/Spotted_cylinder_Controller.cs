using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spotted_cylinder_Controller : MonoBehaviour, IObstacles
{
    public float _speed;
    private float speed;
    private string mainPlayer = "MainPlayer";
    
    
    private void Awake()
    {
    }
    

    private void Start()
    {
        if (transform.position.x > 0) speed = _speed;
        else speed = -_speed;
    }

    void Update()
    {
        Moving();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject && !other.CompareTag(mainPlayer) /*&& CountPlayers.countPlayers > 1*/)
        {
            Destroy(other.gameObject);
            EventManager.OnUpdateCountPlayers(1, false);
           
        }
        /*else if(other.CompareTag(mainPlayer))
        {
            if (CountPlayers.countPlayers == 1)
            {
                
            } Destroy(other.gameObject);

        }*/
    }
    
    public void Moving()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed * 100);
    }
}


