
using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [Tooltip("Персы которые будут спауниться")] [SerializeField] private GameObject[] resources;
    [Tooltip("Радиус в котором будут спауниться персы")] [SerializeField] private float radius;


    private void Start()
    {
        StartCoroutine(Create());
        Debug.Log(2);
        transform.position = new Vector3(transform.position.x, 0, 0);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    IEnumerator Create()
    {
        while (true)
        {
            Spawner();
            yield return new WaitForSeconds(1);
        }
    }

    private void Spawner()
    {
        if (resources != null && resources.Length > 0)
        {
            Debug.Log(1);
            
            var randomResources = Random.Range(0, resources.Length);
          
                Vector2 randomPoint = Random.insideUnitCircle * radius;
                Vector3 pos = transform.position  + new Vector3(randomPoint.x + 0.5f, 0, randomPoint.y + 0.5f);
                Instantiate(resources[randomResources], pos, Quaternion.identity);
        

        }

    }
}
