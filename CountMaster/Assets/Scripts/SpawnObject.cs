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

    private void Awake()
    {
        OnCheckDonut += ChangeScaleDonut;
    }

    private void Start()
    {
      
       StartCoroutine(test());
        transform.position = new Vector3(transform.position.x, 0, 0);
        Spawner();
    }


    IEnumerator test()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Spawner();
        }
    }


    public void Spawner()
    {
        
        
        if (characterPrefab != null && _countPlayers < 60)
        {
            for (int i = 0; i < wayPoints.Count; i++)
            {
                _countPlayers++;
                var b = Instantiate(characterPrefab, wayPoints[i].transform.position, Quaternion.identity,
                    transformParent);
            }
        }

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
        
        if (_countPlayers < 15)
        {
            _donut.transform.localScale = new Vector3(3.5f, 3.5f, 1);
           
        }
        if (_countPlayers > 15 && _countPlayers < 30)
        {
            _donut.transform.localScale = new Vector3(5f, 5f, 1);
        }
        else if (_countPlayers > 30 && _countPlayers < 40)
        {
            _donut.transform.localScale = new Vector3(6, 6, 1);
        }
        else if (_countPlayers > 40 && _countPlayers < 60)
        {
            _donut.transform.localScale = new Vector3(6.5f, 6.5f, 1);
        }
    }

    public void CheckScaleDonut()
    {
        ChangeScaleDonut();
        _countPlayers--;
    }
    
    public void CreatePlayers()
    {
        Spawner();
    }
}