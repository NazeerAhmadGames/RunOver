using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleHealth : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private int hp;

    public UnityEvent onZeroHp;
    void Start()
    {
        displayHp();
    }
 
    public void reduceHealth()
    {
        if (hp>0)
        {
            hp--;
        }
        if (hp<=0)
        {
            onZeroHp.Invoke();
        }
        displayHp();
    }

    private void OnDrawGizmos()
    {
        displayHp();
    }

    public void  displayHp()
    {
        text.text = "" + hp;
    }
}
