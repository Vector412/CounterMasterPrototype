using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;

    [Tooltip("Радиус в котором будут спауниться персы")] [SerializeField]
    private float radius;

    [SerializeField] private List<GameObject> wayPoints = new List<GameObject>();
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject _donut;

  

    public event Action OnCheckDonut;

  
    

    public delegate void OnChangeCrowd();

    private OnChangeCrowd changeCrowd;
    private int _countPlayers = 0;
    private int _allPlayers = 0;

    private void Awake()
    {
      
        OnCheckDonut += ChangeScaleDonut;
    }

    private void Start()
    {
        if(characterPrefab != null)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        
       
    }

    
    public void Spawner(int count)
    {
        _countPlayers = 0;
        if (count < wayPoints.Count)
        {
            var remainder = wayPoints.Count - count;
            for (int i = 0; i < remainder ; i++)
            {
               // wayPoints[i].SetActive(false);
               wayPoints.RemoveAt(0);
            }
        }
        while (_countPlayers < count)
        {
            
            for (int i = 0; i < wayPoints.Count; i++)
            {
              
                var b = Instantiate(characterPrefab, wayPoints[i].transform.position, Quaternion.identity,
                    transformParent);
                _countPlayers++;
            }
        }
      
         _allPlayers += _countPlayers;
         changeCrowd = ChangeScaleDonut;
        changeCrowd();

      
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    public void ChangeScaleDonut()
    {
        
        if (_allPlayers < 15)
        {
            _donut.transform.localScale = new Vector3(3.5f, 3.5f, 1);
        }
        if (_allPlayers > 15 && _allPlayers < 30)
        {
            _donut.transform.localScale = new Vector3(5f, 5f, 1);
        }
        else if (_allPlayers > 30 && _allPlayers < 40)
        {
            _donut.transform.localScale = new Vector3(6, 6, 1);
        }
        else if (_allPlayers > 40 && _allPlayers < 60)
        {
            _donut.transform.localScale = new Vector3(6.5f, 6.5f, 1);
        }
    }

    public void CheckScaleDonut()
    {
        ChangeScaleDonut();
        _allPlayers--;
    }
    
    public void CreatePlayers(int count)
    {
        Debug.Log($"count from wall: {count}");
        Spawner(count);
    }
}