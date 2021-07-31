using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    public Transform player;

    public Chunk[] chunkPrefabs;
    public Chunk firstChunk;
    

    private List<Chunk> spawnedChunks = new List<Chunk>();
    // Start is called before the first frame update
    void Start()
    {
        spawnedChunks.Add(firstChunk);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > spawnedChunks[spawnedChunks.Count - 1].end.position.z - 20)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
      
            Chunk newChunk =  Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count- 1].end.position - newChunk.begin.localPosition ;
            spawnedChunks.Add(newChunk);
        
        
       if (spawnedChunks.Count >= 5)
       {
           Destroy(spawnedChunks[0].gameObject);
           spawnedChunks.RemoveAt(0);
       }
    }
}
