using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> wayPoints = new List<GameObject>();

    [SerializeField] public GameObject enemiesPrefab;
    [SerializeField] public float _minValue;
    [SerializeField] public float _maxValue;

    [SerializeField] private Transform parent;
   
    private int _countEnemies = 0;


    void Start()
    {
      CreateEnemies();
    }


    public void CreateEnemies()
    {
        var _tmp = (int) Random.Range(_minValue, _maxValue);
        _tmp *= 5;
        while (_tmp > _countEnemies)
        {
            for (int i = 0; i < wayPoints.Count; i++)
            {
                var b = Instantiate(enemiesPrefab, wayPoints[i].transform.position, Quaternion.identity, parent);
                _countEnemies++;
            }
        }
    }
    
    

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MainPlayer") )
        {
           
        }
    }*/


 
}