using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    [SerializeField] private GameObject chunk;

    [SerializeField] private int noToSpawn;
    [SerializeField] private float chunkSize;
    private Transform lastSpawned;

    private float lastPos;
    // Start is called before the first frame update
    void Start()
    {
      spawnNow();
    }

    public void spawnNow()
    {
        for (int i = 0; i < noToSpawn; i++)
        {
            GameObject spawnedChunk = Instantiate(chunk);
            spawnedChunk.transform.position = new Vector3(0, 0, lastPos + spawnedChunk.GetComponent<TheLevelChunk>().returnTheSize().z);
            lastPos = spawnedChunk.transform.position.z;
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
