using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheObstacle : MonoBehaviour
{
    public UnityEvent onOneCharacterKill;
   
 
    public void CharacterCameInContact()
    {
        onOneCharacterKill.Invoke();
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
