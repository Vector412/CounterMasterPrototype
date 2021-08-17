using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> wayPoints = new List<GameObject>();

    public GameObject enemiesPrefab;
    public float _minValue;
    public float _maxValue;

    private int _countEnemies = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CreateEnemies()
    {
          yield return new WaitForSeconds(3);
        var _tmp = (int)Random.Range(_minValue, _maxValue);
        _tmp *= 5;
        Debug.Log(_tmp);
      
     
        while (_tmp > _countEnemies )
        {
            for (int i = 0; i < wayPoints.Count; i++)
            {
                var b = Instantiate(enemiesPrefab, wayPoints[i].transform.position, Quaternion.identity);
                _countEnemies++;
            }

           
        }
    }
}
