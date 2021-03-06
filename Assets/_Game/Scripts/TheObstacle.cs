using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheObstacle : MonoBehaviour
{
    public UnityEvent onOneCharacterKill;
    private Transform cam;
    private bool isOffScreen;

 
    public void CharacterCameInContact()
    {
        onOneCharacterKill.Invoke();
    }

    private void Start()
    {
        cam=Camera.main.transform;

    }

    private void Update()
    {
        if (transform.position.z<cam.transform.position.z-5 &&!isOffScreen)
        {
            isOffScreen = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<TheCharacter>())
        {
            col.gameObject.GetComponent<TheCharacter>().onBeingKilled();
            CharacterCameInContact();
           // CrowdSystem.instance.setIfCanMove(false);
        }
    }
}
