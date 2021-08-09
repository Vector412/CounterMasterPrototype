using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;

    [Tooltip("Радиус в котором будут спауниться персы")] [SerializeField]
    private float radius;

    [SerializeField] private List<GameObject> wayPoints = new List<GameObject>();
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject _donut;

    [Range(3, 15)] public float scaleDonut;

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
            Debug.Log(1);
            _donut.transform.localScale = new Vector3(2, 2, 1);
           
        }
        if (_countPlayers > 15 && _countPlayers < 30)
        {
            Debug.Log(2);
            _donut.transform.localScale = new Vector3(4, 4, 1);
        }
        else if (_countPlayers > 30 && _countPlayers < 50)
        {
            Debug.Log(3);
            _donut.transform.localScale = new Vector3(5, 5, 1);
        }
        else if (_countPlayers > 50 && _countPlayers < 60)
        {
            Debug.Log(4);
            
            _donut.transform.localScale = new Vector3(5.5f, 5.5f, 1);
          
        }
    }

    public void CheckScaleDonut()
    {
        ChangeScaleDonut();
        _countPlayers--;
    }
    
    public void CreatePlayers()
    {
        Debug.Log("Add after multiplayer");
        Spawner();
    }
}