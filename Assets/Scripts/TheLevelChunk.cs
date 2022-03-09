using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLevelChunk : MonoBehaviour
{
    [SerializeField] private Vector3 chunkSize;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position+new Vector3(0,0,chunkSize.z/2),chunkSize);
    }

    public Vector3 returnTheSize()
    {
        return chunkSize;
    }
}
