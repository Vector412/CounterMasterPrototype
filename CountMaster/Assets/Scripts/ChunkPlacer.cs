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

    private Renderer _rend;
    

    private List<Chunk> _spawnedChunks = new List<Chunk>();
    // Start is called before the first frame update
  

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _spawnedChunks.Add(firstChunk);
     
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > _spawnedChunks[_spawnedChunks.Count - 1].end.position.z - 20)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
      
            Chunk newChunk =  Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
            newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count- 1].end.position - newChunk.begin.localPosition ;
            _spawnedChunks.Add(newChunk);
        
        
       if (_spawnedChunks.Count >= 5)
       {
           Destroy(_spawnedChunks[0].gameObject);
           _spawnedChunks.RemoveAt(0);
       }
    }


    /*public float WidthObject()
    {
        /*chunkPrefabs[0] = _rend.bounds.extents.magnitude;
        return width;#1#
    }*/
}
