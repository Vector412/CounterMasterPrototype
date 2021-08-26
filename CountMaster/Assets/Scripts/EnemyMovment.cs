using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float maxDistace;
    [SerializeField] GameObject enemy;

    private GameObject target;
    private float dist;

    public event Action OnMoving;

    private IEnumerator checkDistace;

    private void Awake()
    {
        OnMoving += Moving;
        target = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        checkDistace = CheckDistace();
        StartCoroutine(checkDistace);
    }

    IEnumerator CheckDistace()
    {
        while (true)
        {
            dist = Vector3.Distance(target.transform.position, enemy.transform.position);
            if (dist < maxDistace)
            {
                OnMoving?.Invoke();
            }

            yield return null;
        }
    }
    
    public void Moving()
    {
        float step = speed * Time.deltaTime;
        enemy.transform.Translate(Vector3.back * step);
    }
}