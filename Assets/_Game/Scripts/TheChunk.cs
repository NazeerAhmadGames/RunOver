using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheChunk : MonoBehaviour
{

   private Transform cam;

   private bool isRepooled;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z<cam.transform.position.z-20 &&!isRepooled)
        {
            isRepooled = true;
            EnvironmentPooling.instance.repoolNow(transform);
        }
    }

    public void afterRepooled()
    {
        if (isRepooled)
        {
            isRepooled = false;
        }
    }
}
