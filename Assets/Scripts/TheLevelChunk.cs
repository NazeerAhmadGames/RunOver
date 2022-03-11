using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TheLevelChunk : MonoBehaviour
{
    [SerializeField] private Vector3 chunkSize;
    [SerializeField] private int numberOfFollowers;
    [SerializeField] private float[] spawnPositions;
    [SerializeField] private GameObject followerPrefab;
    [SerializeField] private GameObject[] allVehicles;
    [SerializeField] private bool isFirstChunk = true;
    [SerializeField] private Transform vehicleHolder;
    [SerializeField] private int minObstacleHealth=15;

    private int randomMaxHp;
    void OnEnable()
    {
        if (isFirstChunk)
        {
            spawnVehicle();
            spawnFollowers();

        }
    }

    public void setIfIsFirstChunk(bool isFirst)
    {
        isFirst = isFirst;
        if (!isFirst)
        {
           
            foreach (TheFollower f in GetComponentsInChildren<TheFollower>())
            {
                Destroy(f.gameObject);
            }
          
            foreach (CarObstacle c in GetComponentsInChildren<CarObstacle>())
            {
                Destroy(c.gameObject);
            }
        }
    }

    public void spawnVehicle()
    {
        for (int i = 0; i < 3; i++)
        {
            randomMaxHp = UnityEngine.Random.Range(minObstacleHealth, minObstacleHealth * i + 1);
            GameObject spawnedVehicle = Instantiate( returnVehicleWithIndex(i), transform);
            spawnedVehicle.transform.position = vehicleHolder.transform.position+new Vector3(spawnPositions[i],0,0);
            spawnedVehicle.GetComponent<CarObstacle>().updateHp(randomMaxHp);
        }
    }

    public GameObject returnVehicleWithIndex(int index)
    {
        for (int i = 0; i < 10000; i++)
        {
            GameObject randomObj = allVehicles[UnityEngine.Random.Range(0, allVehicles.Length)];
            if (randomObj.GetComponent<CarObstacle>().returnTheTypeOfCar()==index)
            {
                return randomObj;
            }
           
        }

        return null;
    }

    public void spawnFollowers()
    {
        numberOfFollowers = (randomMaxHp+10)/5;
        for (int i = 0; i < numberOfFollowers; i++)
        {
            Vector3 randomPos = generateRandomVectorOnChunk();

            for (int j = 0; j < 5; j++)
            {

                if (isFeasiblePosition(randomPos))
                {
                    GameObject spawnedFollower = Instantiate(followerPrefab, transform);
                    spawnedFollower.transform.position = randomPos;
                    spawnedFollower.transform.eulerAngles = new Vector3(0, UnityEngine.Random.Range(-360, 360), 0);
                    randomPos = generateRandomVectorInGroup(spawnedFollower.transform.position);
                }
                else
                {
                    i--;
                }    
            }
        
        }
    }

    private void Start()
    {
      
    }

    void Update()
    {
      
    }

    public Vector3 generateRandomVectorOnChunk()
    {
        return new Vector3(UnityEngine.Random.Range(-chunkSize.x/2, chunkSize.x/2),
            0.61f, UnityEngine.Random.Range(transform.position.z+20,transform.position.z+ chunkSize.z-20));
    }
    public Vector3 generateRandomVectorInGroup(Vector3 lastFollower,float offset=5)
    {
        return new Vector3(UnityEngine.Random.Range(lastFollower.x+offset, lastFollower.x-offset),
            0.61f, UnityEngine.Random.Range(lastFollower.z+offset,lastFollower.z-offset));
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position+new Vector3(0,0,chunkSize.z/2),chunkSize);
    }

    public Vector3 returnTheSize()
    {
        return new Vector3(0,0,chunkSize.z);
    }

    public bool isFeasiblePosition(Vector3 posToCheck)
    {
        bool didHit = false;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(posToCheck, Vector3.down, out hit, Mathf.Infinity))
        {
          //  Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.tag=="Ground")
            {
                didHit = true;
            }
        }
       
        return true;
    }
}
