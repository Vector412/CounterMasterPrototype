using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkPlacer : MonoBehaviour
{
    public Transform player;
    public Chunk[] chunkPrefabs;
    public Chunk firstChunk;
    

    private List<Chunk> _spawnedChunks = new List<Chunk>();

    private AIController aiController;


    private void Start()
    {
        _spawnedChunks.Add(firstChunk);
      
    }
    

    private void Update()
    {
        if (player.position.z > _spawnedChunks[_spawnedChunks.Count - 1].end.position.z - 10)
        {
            SpawnChunk();
          
          
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
       
        newChunk.transform.position =
            _spawnedChunks[_spawnedChunks.Count - 1].end.position - newChunk.begin.localPosition;
        _spawnedChunks.Add(newChunk);
     
       

        if (_spawnedChunks.Count >= 5)
        {
            Destroy(_spawnedChunks[0].gameObject);
            _spawnedChunks.RemoveAt(0);
        }

       
    }

 
}