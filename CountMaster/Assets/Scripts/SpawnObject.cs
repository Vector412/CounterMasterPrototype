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
    
   

    public delegate void OnChangeCrowd();
    private OnChangeCrowd changeCrowd;
    private int _countPlayers = 0;
    
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


    private void Spawner()
    {
        if (characterPrefab != null && _countPlayers < 60  )
        {
            for (int i = 0; i < wayPoints.Count; i++)
            {
                _countPlayers++;
                var b = Instantiate(characterPrefab, wayPoints[i].transform.position, Quaternion.identity, transformParent);
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


    private void ChangeScaleDonut()
    {
        
        if (_countPlayers > 10 && _countPlayers < 30)
        {
            _donut.transform.localScale *= 1.5f;


        }
        else if(_countPlayers > 30 && _countPlayers < 50)
        {
           
            _donut.transform.localScale *= 1.6f;
               
        }
        else if(_countPlayers > 50 && _countPlayers < 60)
        {
            
            _donut.transform.localScale *= 1.7f;
               
            
        }
    }
}