using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotted_cylinder_Controller : MonoBehaviour, IObstacles
{
    public float _speed;
    private float speed;
    private string mainPlayer = "MainPlayer";
    public event Action OnKill;

    
    private void Awake()
    {
        OnKill += Listener.Instance.KillPlayers;
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
