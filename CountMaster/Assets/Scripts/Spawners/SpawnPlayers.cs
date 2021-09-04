using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;

    [Tooltip("Радиус в котором будут спауниться персы")] [SerializeField]
    private float radius;

    [SerializeField] private List<GameObject> wayPoints = new List<GameObject>();
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject _donut;

    
    private void Awake()
    {
        EventManager.SpawnPlayers += Spawner;
    }

    private void Start()
    {
        if(characterPrefab != null)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        } 
    }
    
    private void Spawner(int count)
    {
        if (count < wayPoints.Count)
        {
            var remainder = wayPoints.Count - count;
            for (int i = 0; i < remainder ; i++)
            {
                wayPoints.RemoveAt(0);
            }
        }
        for (int i = 0; i < wayPoints.Count; i++)
            {
                var b = Instantiate(characterPrefab, wayPoints[i].transform.position, Quaternion.identity,
                    transformParent);
            }
        EventManager.OnUpdateCountPlayers(count,true);
        
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    

    private void OnDestroy()
    {
        EventManager.SpawnPlayers -= Spawner;
    }

   
}