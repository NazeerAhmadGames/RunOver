using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFollower : MonoBehaviour
{
    private bool hasJoined;
    [SerializeField] private GameObject vfxOnJoining,plusOnePopUp;
    [SerializeField] private Animator myAnim;
    [SerializeField] private float distanceBeforeStartRunning=20;
    [SerializeField] private float runAwaySpeed=2;
    private bool isrunning,isDead;
    private Transform cam;
    private bool isOffScreen;
    void OnEnable()
    {
        StartCoroutine(delayedCheckForPlayer());
    }

    private void Start()
    {
        cam=Camera.main.transform;

    }

    void Update()
    {
        if (isrunning)
        {
            transform.position+=transform.forward
            *runAwaySpeed * Time.deltaTime;
        }
        
        if (transform.position.z<cam.transform.position.z-20 &&!isOffScreen)
        {
            isOffScreen = true;
            Destroy(gameObject);
        }
    }

    IEnumerator delayedCheckForPlayer()
    {
        yield return new WaitForSeconds(.1f);
        if (CrowdSystem.instance.firstRow!=null&& !isrunning)
        {
            if (Vector3.Distance(transform.position,CrowdSystem.instance.firstRow.transform.position)<=distanceBeforeStartRunning)
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

            if (FinishLine.instance.returnIfCrossed()==false)
            {
                PlayerController.instance.addMoreCharacters(1);

            }

            else
            {
                EndingGiant.instance.increaseGiantSize();
            }

            GameObject spawnedPlusOne=Instantiate(plusOnePopUp);
            spawnedPlusOne.transform.position = plusOnePopUp.transform.position;
            spawnedPlusOne.SetActive(true);
            spawnedPlusOne.transform.parent = null;
            Destroy(spawnedPlusOne,2);
            
            vfxOnJoining.transform.parent = null;
            vfxOnJoining.SetActive(true);
            Destroy(vfxOnJoining,2);
            HapticManager.instance.playTheLightHaptics();

            Destroy( gameObject); 
        }
       
        
        if (col.gameObject.GetComponentInParent<TheObstacle>()&& !isDead)
        {
            isDead = true;
         /*
            vfxOnJoining.transform.parent = null;
            vfxOnJoining.SetActive(true);
            Destroy(vfxOnJoining,2);
            HapticManager.instance.playTheLightHaptics();
*/
            Destroy( gameObject); 
        }
    }
}
