using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheCharacter : MonoBehaviour
{

   [HideInInspector] public RowSystem myRow;
    [SerializeField] private float followSpeed=30;
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject killVfx;
    private Transform targetToFollow;
    
    private bool isDead;
    
    public void onBeingKilled()
    {
        if (isDead==false)
        {
            isDead = true;  
            killVfx.transform.parent = null;
            killVfx.SetActive(true);
            Destroy(killVfx,2);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        CrowdSystem.instance.RemoveCharacter(this,myRow);
    }
}
