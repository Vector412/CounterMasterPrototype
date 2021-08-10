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
    public Chunk finishChunk;
    
    private List<Chunk> _spawnedChunks = new List<Chunk>();
    
    
    
    public float _minValueChunks ;
    public float _maxValueChunks ;
    private int _tmpCountChunks;
    private int _counterChunks = 0;

    private Transform lastChunkPosition = null;

    private void Start()
    {
        _tmpCountChunks = (int)Random.Range(_minValueChunks, _maxValueChunks);
        Debug.Log(_tmpCountChunks);
        _spawnedChunks.Add(firstChunk);
        for (int i = 0; i < _tmpCountChunks; i++)
        {
            SpawnChunk();
        }
      
    }
    

    private void Update()
    {
        if (player.position.z > _spawnedChunks[_spawnedChunks.Count - 1].end.position.z - 3)
        {
            for (int i = 0; i < _spawnedChunks.Count - 3; i++)
            {
                Destroy(_spawnedChunks[0].gameObject);
                _spawnedChunks.RemoveAt(0);
            }
           
        
        }
    }

    public void SpawnChunk()
    {
        Transform tmp;
        _counterChunks++;
        if (_counterChunks != _tmpCountChunks)
        {
            Chunk currentChunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
       
            
            currentChunk.transform.position =
                _spawnedChunks[_spawnedChunks.Count - 1].end.position - currentChunk.begin.localPosition;
            _spawnedChunks.Add(currentChunk);

            
            
            
            
         
        }
        else
        {
            Chunk lastChunk = Instantiate(finishChunk);

            lastChunk.transform.position =
                _spawnedChunks[_spawnedChunks.Count - 1].end.position - lastChunk.begin.localPosition;
            _spawnedChunks.Add(lastChunk);
            
        }




   

        /*if (_spawnedChunks.Count >= 5)
        {
            Destroy(_spawnedChunks[0].gameObject);
            _spawnedChunks.RemoveAt(0);
        }*/
        
    }
    
    
   


 
}