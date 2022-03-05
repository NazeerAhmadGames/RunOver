using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheCharacter : MonoBehaviour
{

    public RowSystem myRow;
    [SerializeField] private float followSpeed=30;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform targetToFollow;
    
    private bool isDead;
    
    public void onBeingKilled()
    {
        if (isDead==false)
        {
            isDead = true;  
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        CrowdSystem.instance.RemoveCharacter(this,myRow);
    }
}
