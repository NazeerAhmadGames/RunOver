using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeRandomizer : MonoBehaviour
{
    [SerializeField] private float min, max;
  //  [SerializeField] private int destroyFactor;
 //   [SerializeField] private bool destroyRandom;
    [SerializeField] private bool uniform;
    [SerializeField] private bool nonUniformX;
    [SerializeField] private bool nonUniformY;
    [SerializeField] private bool nonUniformZ;
    
   
    // Start is called before the first frame update
    void Start()
    {
        if (uniform)
        {
            float randomSize=UnityEngine.Random.Range(min,max);
            transform.localScale = new Vector3(randomSize,randomSize,randomSize);
        }
        if (nonUniformX)
        {
            float randomSize=UnityEngine.Random.Range(min,max);
            transform.localScale = new Vector3(randomSize,transform.localScale.y,transform.localScale.z);
        }
        if (nonUniformY)
        {
            float randomSize=UnityEngine.Random.Range(min,max);
            transform.localScale = new Vector3(transform.position.x,randomSize,transform.localScale.z);
        }
        if (nonUniformZ)
        {
            float randomSize=UnityEngine.Random.Range(min,max);
            transform.localScale = new Vector3(transform.position.x,transform.position.y,randomSize);
        }

      

    }
/*
    public void randomDestroy()
    {
        if (destroyRandom)
        {
            if (UnityEngine.Random.Range(0,destroyFactor)-destroyFactor<1)
            {
                Destroy(gameObject);
            }
        }
    }
*/
   
}
