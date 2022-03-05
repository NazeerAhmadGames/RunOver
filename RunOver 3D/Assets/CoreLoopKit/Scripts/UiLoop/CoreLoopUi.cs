using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
using UnityEditor;

public class CoreLoopUi : MonoBehaviour
{
    [SerializeField] private GameObject startingPanel,commonLevel;
    [SerializeField] private GameObject WinPanel, deathPanel, hudCanvas;


    public static CoreLoopUi instance;


    private bool hasWon, hasLost;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        
    }


    public void onWinningGame()
    {
        if (hasWon == false)
        {
            hasWon = true;
            StartCoroutine(winSequence());
           // GameplayUiFeedback.instance.onGameWin();
        }
    }

    IEnumerator winSequence()
    {
        yield return new WaitForSeconds(1f);
        WinPanel.SetActive(true);
        hudCanvas.gameObject.SetActive(false);
        //  LevelingSystem.instance.UpdatePlayerPRefs();
          FlipsUiManager.instance.onCompletingLevel();
     //TinySauce.OnGameFinished(true, 0, "Level" + PlayerPrefs.GetInt("CURRENTLEVEL"));
        DiamondRewardSystem.instance.setTheDiamondsAmount_EndGame();
        HapticManager.instance.playTheSoftHaptics();
        hudCanvas.gameObject.SetActive(false);
    }

    public void onLoosingGame()
    {
        if (hasLost == false)
        {
            hasLost = true;
            StartCoroutine(looseSequence());
           
        }
    }


    IEnumerator looseSequence()
    {
        yield return new WaitForSeconds(1.5f);
        deathPanel.SetActive(true);
        hudCanvas.gameObject.SetActive(false);
        HapticManager.instance.playTheSoftHaptics();
        //CustomAds.instance.showFullScreenAd();

     // TinySauce.OnGameFinished(false, 0, "Level" + PlayerPrefs.GetInt("CURRENTLEVEL"));
    }


    public bool checkIfWon()
    {
        return hasWon;
    }
    public bool checkIfLost()
    {
        return hasLost;
        
    }

    public void restartTheLevel(bool isWinButton)
    {
        HapticManager.instance.playTheSoftHaptics();
        if (isWinButton && DiamondRewardSystem.instance.returnTheDiamonds()>0)
        {
            DiamondRewardSystem.instance.spawnEndGameDiamonds(DiamondRewardSystem.instance.returnTheDiamonds());
            StartCoroutine(restartSequence(2f));
        }
        else
        {
            StartCoroutine(restartSequence(.01f));
        }
    }

    IEnumerator restartSequence(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(commonLevel);
        Application.LoadLevel(0);
    }

   
    public void RateTheGame()
    {
        if (Application.platform==RuntimePlatform.Android)
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.catobilli.phonerun");
        }
        else  if (Application.platform==RuntimePlatform.IPhonePlayer)
        {
            Application.OpenURL("https://apps.apple.com/app/phone-run-3d/id1583584781");
        }
        else
        {
            Application.OpenURL("https://play.google.com/store/apps/details?id=com.catobilli.phonerun");
            Application.OpenURL("https://apps.apple.com/app/phone-run-3d/id1583584781");
        }
    }
}
