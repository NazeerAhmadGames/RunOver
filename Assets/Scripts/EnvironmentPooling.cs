using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPooling : MonoBehaviour
{
   private Transform[] allChunks;
  [SerializeField] private float chunkSize=30;

   public static EnvironmentPooling instance;
    // Start is called before the first frame update
    void Start()
    {
        allChunks = new Transform[transform.childCount];
        for (int i = 0; i < allChunks.Length; i++)
        {
            allChunks[i] = transform.GetChild(i);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void repoolNow(Transform chunk)
    {
        float[] allPosition = new float[allChunks.Length];
        for (int i = 0; i < allPosition.Length; i++)
        {
            allPosition[i] = allChunks[i].position.z;
        }
       
        for (int i = 0; i < allChunks.Length; i++)
        {
            if (  Mathf.Max(allPosition)-allChunks[i].transform.position.z <=1f)
            {
                chunk.transform.position = new Vector3(chunk.transform.position.x,chunk.transform.position.y,allChunks[i].transform.position.z+chunkSize) ;
                chunk.GetComponent<TheChunk>().afterRepooled();
                return;
            }
        }
        
       
    }
}
