using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFollower : MonoBehaviour
{
    private bool hasJoined;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<TheCharacter>() && !hasJoined)
        {
            hasJoined = true;
            PlayerController.instance.addMoreCharacters(1);
          Destroy( gameObject); 
        }
    }
}
