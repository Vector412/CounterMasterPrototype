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
        if (characterPrefab != null )
        {
            for (int i = 0; i < wayPoints.Count; i++)
            {
                /*Vector2 randomPoint = Random.insideUnitCircle * radius;
                Vector3 pos = transform.position + new Vector3(randomPoint.x + 0.5f, 0, randomPoint.y + 0.5f);*/

                var b = Instantiate(characterPrefab, wayPoints[i].transform.position, Quaternion.identity,transformParent);
            }
        }
    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}