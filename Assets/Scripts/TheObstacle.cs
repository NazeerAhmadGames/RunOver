using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheObstacle : MonoBehaviour
{
    public UnityEvent onOneCharacterKill;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
