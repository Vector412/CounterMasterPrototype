using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
        _counterChunks++;
        if (_counterChunks != _tmpCountChunks)
        {
            Chunk currentChunk = Instantiate(GetRandomChunk());
            CalculateNextChunk(currentChunk);
        }
        else
        {
            Chunk lastChunk = Instantiate(finishChunk);
            CalculateNextChunk(lastChunk);
            
        }
    }
    


    private void CalculateNextChunk(Chunk chunk)
    {
        chunk.transform.position =
            _spawnedChunks[_spawnedChunks.Count - 1].end.position - chunk.begin.localPosition;
        _spawnedChunks.Add(chunk);
    }

    private Chunk GetRandomChunk()
    {
        List<float> chances = new List<float>();
        for (int i = 0; i < chunkPrefabs.Length; i++)
        {
            chances.Add(chunkPrefabs[i].chanceFromDistance.Evaluate(chunkPrefabs[i].transform.position.z));
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;
        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if (value < sum)
            {
                return chunkPrefabs[i];
            }
        }

        return chunkPrefabs[chunkPrefabs.Length - 1];
    }
    





}