using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFollower : MonoBehaviour
{
    private bool hasJoined;
    [SerializeField] private GameObject vfxOnJoining;
    [SerializeField] private Animator myAnim;
    [SerializeField] private float distanceBeforeStartRunning=20;
    [SerializeField] private float runAwaySpeed=2;
    private bool isrunning;
    void OnEnable()
    {
        StartCoroutine(delayedCheckForPlayer());
    }

    void Update()
    {
        if (isrunning)
        {
            transform.position+=transform.forward
            *runAwaySpeed * Time.deltaTime;
        }
    }

    IEnumerator delayedCheckForPlayer()
    {
        yield return new WaitForSeconds(.1f);
        if (CrowdSystem.instance.transform.childCount>0 && !isrunning)
        {
            if (Vector3.Distance(transform.position,CrowdSystem.instance.transform.GetChild(0).position)<=distanceBeforeStartRunning)
            {
                if (!isrunning)
                {
                    isrunning = true;
                    myAnim.Play("Run");
                }
            }

        }
      
        StartCoroutine(delayedCheckForPlayer());
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<TheCharacter>() && !hasJoined)
        {
            hasJoined = true;
            PlayerController.instance.addMoreCharacters(1);
            vfxOnJoining.transform.parent = null;
            vfxOnJoining.SetActive(true);
            Destroy(vfxOnJoining,2);
            Destroy( gameObject); 
        }
    }
}
