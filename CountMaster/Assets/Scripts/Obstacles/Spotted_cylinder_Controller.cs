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
 
    
    private GameObject container = null;
    
    private void Awake()
    {
        EventManager.MinusPlayers += EventAboutDestroy;
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
        if (gameObject && !other.CompareTag(mainPlayer))
        {
            Destroy(other.gameObject);
         //   EventAboutDestroy();
           
        }
        /*else if(other.CompareTag(mainPlayer))
        {
            OnGameOver?.Invoke();
        }*/
    }

    private void EventAboutDestroy()
    {
       // EventManager.OnMinusPlayers();
    }






    public void Moving()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed * 100);
    }
}
