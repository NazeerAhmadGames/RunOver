using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class MovesUiManager : MonoBehaviour
{
    public static MovesUiManager instance;

    private int availableMoves;
    [SerializeField] private Text movesText;

    void Awake()
    {
        instance = this;
    }

    public void increaseTheMovesCount(int amount)
    {
        availableMoves = amount;
        DangerEffect.instance.stopTheEffect();
//        movesText.text = "" + availableMoves;
    }
    public void decreaseTheMoves()
    {
        if (availableMoves > 0)
        {
            availableMoves--;
        }
        if (availableMoves <= 0)
        {
            StartCoroutine(gameOverWithDelay());
        }

//        movesText.text = "" + availableMoves;
    }

    IEnumerator gameOverWithDelay()
    {
        yield return new WaitForSeconds(2);
       // DangerEffect.instance.startingTheEffect(2);

      //  yield return new WaitForSeconds(3);
        if (availableMoves <= 0)
        {
            CoreLoopUi.instance.onLoosingGame();
        }
    }

    public int returnTheAvailableMoves()
    {
        return availableMoves;
    }

}
