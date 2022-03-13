using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingChunk : MonoBehaviour
{
    [SerializeField] private int totalToSpawn;
    [SerializeField] private float tileSize;
    [SerializeField] private GameObject tileToSpawn;
    [SerializeField] private GameObject followerPrefab;
    [SerializeField] private Vector3 chunkSize;
    [SerializeField] private int numberOfFollowers;

    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        tileToSpawn.SetActive(false);
        lastPos = tileToSpawn.transform.position;
        spawnAllTiles();
        spawnFollowers();
    }

    public void spawnAllTiles()
    {
        for (int i = 0; i < totalToSpawn; i++)
        {
            GameObject spawnedChunk = Instantiate(tileToSpawn,transform);
            spawnedChunk.transform.position = lastPos;
            lastPos = spawnedChunk.transform.position+new Vector3(0,0,tileSize);
            spawnedChunk.SetActive(true);
            spawnedChunk.GetComponent<EndingTile>().updateValue(i+1);
        }
    }

    public void spawnFollowers()
    {
        for (int i = 0; i < numberOfFollowers/5; i++)
        {
            Vector3 randomPos = generateRandomVectorOnChunk();

            for (int j = 0; j < 5; j++)
            {
                    GameObject spawnedFollower = Instantiate(followerPrefab, transform);
                    spawnedFollower.transform.position = randomPos;
                    spawnedFollower.transform.eulerAngles = new Vector3(0, UnityEngine.Random.Range(-360, 360), 0);
                    randomPos = generateRandomVectorInGroup(spawnedFollower.transform.position);
            }
        
        }
    }
    public Vector3 generateRandomVectorOnChunk()
    {
        return new Vector3(UnityEngine.Random.Range(-chunkSize.x/2, chunkSize.x/2),
            0.61f, UnityEngine.Random.Range(transform.position.z,transform.position.z+ chunkSize.z-50));
    }
    public Vector3 generateRandomVectorInGroup(Vector3 lastFollower,float offset=5)
    {
        return new Vector3(UnityEngine.Random.Range(lastFollower.x+offset, lastFollower.x-offset),
            0.61f, UnityEngine.Random.Range(lastFollower.z+offset,lastFollower.z-offset));
    }
}
