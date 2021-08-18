using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Axe_Controller : MonoBehaviour, IObstacles
{
    public GameObject axe_handle;
    private string mainPlayer = "MainPlayer";
    public event Action OnKill;
    public event Action OnGameOver;

    private void Start()
    {
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
        else if (other.CompareTag(mainPlayer))
        {
            OnGameOver?.Invoke();
        }
    }

    public void DestroyObjects(Collider col)
    {
        Destroy(col.gameObject);
        OnKill?.Invoke();
    }

    public void Moving()
    {
        float angle = Mathf.Sin(Time.time) * 60; //tweak this to change frequency

        axe_handle.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);

        
    }
}