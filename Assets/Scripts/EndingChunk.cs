using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingChunk : MonoBehaviour
{
    [SerializeField] private int totalToSpawn;
    [SerializeField] private float tileSize;
    [SerializeField] private GameObject tileToSpawn;

    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        tileToSpawn.SetActive(false);
        lastPos = tileToSpawn.transform.position;
        spawnAllTiles();
    }

    public void spawnAllTiles()
    {
        for (int i = 0; i < totalToSpawn; i++)
        {
            GameObject spawnedChunk = Instantiate(tileToSpawn);
            spawnedChunk.transform.position = lastPos;
            lastPos = spawnedChunk.transform.position+new Vector3(0,0,tileSize);
            spawnedChunk.SetActive(true);
        }
    }
}
