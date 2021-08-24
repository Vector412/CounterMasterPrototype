using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField] public float speed;
    public GameObject target;
    public GameObject  enemy;

    private float dist;
    private void Awake()
    {
       // StartCoroutine(CountTime());
    }

    void Update()
    {
        dist = Vector3.Distance(target.transform.position, enemy.transform.position);
        if (dist < 30)
        {
            Moving();
        }
       // Moving();
    }

    public void Moving()
    {
        float step = speed * Time.deltaTime;
        enemy.transform.Translate(Vector3.back * step);
    }

    /*IEnumerator CountTime()
    {
       
        while (true)
        {
            
            if (dist < 30)
            {
                Debug.Log(111);
                Moving();
              
            }
            yield return new WaitForSeconds(1);
        }
        
        
            
    }*/


}