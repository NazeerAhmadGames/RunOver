using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingTile : MonoBehaviour
{
    [SerializeField] private int amount;

    [SerializeField] private TextMeshPro text;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material landedOnMat;

    private bool hasActivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void landedOn()
    {
        if (!hasActivated)
        {
            hasActivated = true;
            meshRenderer.material = landedOnMat;
            EndingCar.instance.updateCurrentBonusAmount(amount);
        }
    }

    public void updateValue(int value)
    {
        amount = value;
        text.text = "" + amount;
    }
}
