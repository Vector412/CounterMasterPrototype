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
    public event Action OnKill;
    public event Action OnGameOver;
   

    
    private void Awake()
    {
        OnKill += Listener.Instance.KillPlayers;
        OnGameOver += Listener.Instance.GameEnd;
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
            DestroyObjects(other);
        }
        else if(other.CompareTag(mainPlayer))
        {
            OnGameOver?.Invoke();
        }
    }
    
    public  void DestroyObjects(Collider col)
    {
        Destroy(col.gameObject);
        OnKill?.Invoke();
    }

    public void Moving()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed * 100);
    }
}
