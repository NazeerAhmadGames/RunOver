using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using MoreMountains.NiceVibrations;


public class LevelingSystem : MonoBehaviour
{
    public Text CurrentLevelText;
  // public Text nextLevelText;

    //public Text winPanelScore;
   //public Text winPanelBestTitle;

    //public Text loosePanelScore;
    //public Text loosePanelBestTitle;

    //public Text hudBestScore;

    public static LevelingSystem instance;
    public int totalLevel;


    void Awake()
    {

        if (PlayerPrefs.GetInt("start", 0) == 0)
        {
            PlayerPrefs.SetInt("start", 1);
            OneTimeInitializier();
        }
       
        instance = this;


       
    }
    // Use this for initialization
    void Start()
    {

        CurrentLevelText.text = ""+ PlayerPrefs.GetInt("CURRENTLEVEL");
      //  nextLevelText.text = "" + PlayerPrefs.GetInt("NEXTLEVEL");

        int i = PlayerPrefs.GetInt("CURRENTLEVEL");


       // hudBestScore.text = "Best:" + PlayerPrefs.GetInt("BEST");

    }
    void OneTimeInitializier()
    {
        PlayerPrefs.SetInt("CURRENTLEVEL", 1);
        PlayerPrefs.SetInt("NEXTLEVEL", 2);
       
        PlayerPrefs.SetInt("DIAMONDS", 0);
        PlayerPrefs.SetInt("COLOR", 0);
        PlayerPrefs.SetInt("SOUND", 1);
        PlayerPrefs.SetInt("VIBRATION", 1);
        PlayerPrefs.SetInt("BEST", 0);
        PlayerPrefs.SetInt("SCENEX", 1);

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N))
        {

            UpdatePlayerPRefs();
            Application.LoadLevel(0);

        }

    }
   
    public void UpdatePlayerPRefs()
    {
        PlayerPrefs.SetInt("CURRENTLEVEL", PlayerPrefs.GetInt("CURRENTLEVEL") + 1);
        PlayerPrefs.SetInt("NEXTLEVEL", PlayerPrefs.GetInt("NEXTLEVEL") + 1);
        
        PlayerPrefs.SetInt("SCENEX", PlayerPrefs.GetInt("SCENEX") + 1);
        if (PlayerPrefs.GetInt("SCENEX") >LevelLoader.instance.totalLevels)
        {
            PlayerPrefs.SetInt("SCENEX", 6);
        }
    }
    /*
    public void checkForHighScore()
    {
        if (UiManager.instance.Score > PlayerPrefs.GetInt("BEST"))
        {
            PlayerPrefs.SetInt("BEST", UiManager.instance.Score);
        }
        else
        {
           
            winPanelBestTitle.text = "Score";
            loosePanelBestTitle.text = "Score";
        }
        showScoresOnPanel();
    }


    public void showScoresOnPanel()
    {
        winPanelScore.text = "" + UiManager.instance.Score;
        loosePanelScore.text = "" + UiManager.instance.Score;

    }
    */
}
