using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheCharacter : MonoBehaviour
{

    [SerializeField] private float followSpeed=30;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform targetToFollow;

    private CrowdSystem crowdSystem;

    private bool isDead;
    void Start()
    {
        crowdSystem = GetComponentInParent<CrowdSystem>();
    }

    void Update()
    {
        if (targetToFollow!=null)
        {
            transform.position = Vector3.Lerp(transform.position, targetToFollow.position - offset,
                followSpeed * Time.deltaTime);
            transform.LookAt(targetToFollow);
        }
    }

    public void setFollowTarget(Transform target)
    {
        
            targetToFollow = target;
        
    }

    public void onBeingKilled()
    {
        if (isDead==false)
        {
            isDead = true;
           // Destroy(gameObject);
           crowdSystem.removeOneCharacter();
        }
    }

   
}
