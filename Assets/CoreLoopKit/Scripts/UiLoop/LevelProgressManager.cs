using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;

public class LevelProgressManager : MonoBehaviour
{
    [SerializeField] private Slider slider;


    public static LevelProgressManager instance;
    void Awake()
    {
        instance = this;
        
    }

    public void UpdateTheProgress()
    {
       slider.value =  CrowdSystem.instance.firstRow.transform.position.magnitude/ FinishLine.instance.transform.position.magnitude;
    }

    private void Update()
    {
      
        if(FinishLine.instance!=null)
        {
            UpdateTheProgress();
        }
       
    }
}
