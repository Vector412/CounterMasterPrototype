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

    private int killedPlayersCount= 0;
    private GameObject container = null;
    
    public delegate void OnKill(int count);

    private OnKill kill;
    private void Awake()
    {
        kill = EventAboutDestroy;
       // EventManager.UpdatePlayerCount += EventAboutDestroy;
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
            killedPlayersCount++;
            Destroy(other.gameObject);
            if (killedPlayersCount > 10)
            {
                kill(killedPlayersCount);
            }
        }
        /*else if(other.CompareTag(mainPlayer))
        {
            OnGameOver?.Invoke();
        }*/
    }
    

    
    private void EventAboutDestroy(int count)
    {
        EventManager.OnUpdatePlayerCount(count, false);
    }
    






    public void Moving()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed * 100);
    }
}


