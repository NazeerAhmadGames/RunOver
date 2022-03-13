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
    [SerializeField] private Animator myAnim;
    private Transform targetToFollow;

    private Transform giantLeader;
    
    private bool isDead,hasMerged,isGiantLeader;
    
    
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

    private void Update()
    {
        if (giantLeader!=null)
        {
            moveTowardsGiant();
        }
      
    }

    public void moveTowardsGiant()
    {
        transform.position =
            Vector3.Lerp(transform.position, giantLeader.transform.position, followSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position,giantLeader.transform.position)<=.2f&&!hasMerged)
        {
            hasMerged = true;
            EndingGiant.instance.increaseGiantSize();
            Destroy(gameObject);
        }
    }

    public void mergeIntoGiant(TheCharacter leader)
    {
        if (!isGiantLeader)
        {
            giantLeader = leader.transform;
        }
    }

    public void setMeAsGiantLeader(bool isLeader)
    {
        isGiantLeader = isLeader;
    }

    public void playAnimation(string stateName)
    {
        myAnim.Play(stateName);
    }
    
}
