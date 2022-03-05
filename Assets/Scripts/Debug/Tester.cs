using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tester : MonoBehaviour
{
    public Tester parent;
    private void Update()
    {
        if (parent)
        {
            Vector3 pos = transform.position;
            Vector3 dir = parent.transform.position - pos;
            float mag = dir.magnitude;
            if (mag>1)
            {
                transform.position =parent.transform.position -dir.normalized;
            }
        } 
    }
}
