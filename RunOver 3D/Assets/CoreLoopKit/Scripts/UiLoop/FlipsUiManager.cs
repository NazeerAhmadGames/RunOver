using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Serialization;

public class FlipsUiManager : MonoBehaviour
{
    [SerializeField] private GameObject flipXText;
    [SerializeField] private GameObject[] objectiveTicks;
    [SerializeField] private GameObject[] starsWinScreen;
    [SerializeField] private Text[] objectiveText;
    [SerializeField] private TextMeshProUGUI[] objectiveTextWinScreen;
    [SerializeField] private Image[] objectivesLabel;
    [FormerlySerializedAs("completedStarLabel")] [SerializeField] private Sprite completedObjectiveLabel;


    private int currentObjectiveIndex;
    private bool hasWon;

    public static FlipsUiManager instance;



    void Awake()
    {
        instance = this;
    }
    
  
    public void showFeedBackText(int totalFlips)
    {
        flipXText.transform.localScale=Vector3.one;
        flipXText.GetComponent<Text>().text = "Flip X" + totalFlips;
        flipXText.SetActive(true);
        flipXText.GetComponent<DOTweenAnimation>().DORestartById("Shake");
    }

    IEnumerator delalyedScaleDown(GameObject objToAnimate)
    {
        yield return new WaitForSeconds(.1f);
        if (flipXText.activeInHierarchy)
        {
            objToAnimate.transform.DOScale(0, .3f);
        }
    }
    public void hideFlipsCounterText()
    {
        flipXText.SetActive(false);
    }

    public void updateHudObjectives(int index)
    {
        objectiveTicks[index].SetActive((true));
    }

    public void setTheObjectivesValue(int index,int flipsToDo)
    {
        objectiveText[index].text = "" + flipsToDo;
        objectiveTextWinScreen[index].text = "" + flipsToDo +" Flips";
    }

   
    public void onCompletingLevel()
    {
      //  StartCoroutine(startStarsSequence());
    }
    /*
    IEnumerator startStarsSequence()
    {
        for (int i = 0; i < FlipsCounter.instance.returnTheObjectivesArray().Length; i++)
        {
            yield return new WaitForSeconds(.3f);
            if (FlipsCounter.instance.returnTheTotalFlips()>=FlipsCounter.instance.returnTheObjectivesArray()[i])
            {
                starsWinScreen[i].SetActive(true);
                objectivesLabel[i].sprite = completedObjectiveLabel;
                objectivesLabel[i].color = Color.white;
            }
        }
    }
    
    */
}
