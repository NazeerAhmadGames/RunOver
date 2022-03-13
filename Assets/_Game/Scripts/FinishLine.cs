using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool hasCrossed;

    public static FinishLine instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<TheCharacter>() &&!hasCrossed)
        {
            hasCrossed = true;
        //    PlayerController.instance.setIfCanMove(false);
            EndingGiant.instance.mergeAllCharacters(col.gameObject.GetComponent<TheCharacter>());
        }
    }

    public bool returnIfCrossed()
    {
        return hasCrossed;
    }
}
