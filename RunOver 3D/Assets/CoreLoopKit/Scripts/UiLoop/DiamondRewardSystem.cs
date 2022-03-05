using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DiamondRewardSystem : MonoBehaviour
{
    [SerializeField] private GameObject flyingDiamond,panel,nextButton,restartButton;
    [SerializeField] private TextMeshProUGUI diamondCollectedText,totalDiamondsText;
    [SerializeField] private float coinMin, coinMax;
    private int InGameDiamondAmount=0;
    private int diamonds,multiplyer;
    public static DiamondRewardSystem instance;

    void Awake()
    {
        instance = this;
        multiplyer = 1;
    }
 
    public void SpawnIngameDiamond()
    {
        GameObject go = Instantiate(flyingDiamond, flyingDiamond.transform.parent);
        go.transform.position = new Vector3(flyingDiamond.transform.position.x + Random.Range(coinMin, coinMax), flyingDiamond.transform.position.y + Random.Range(coinMin, coinMax), 0);
        go.SetActive(true);
        go.GetComponent<CoinMovingUi>().EndGameDiamond=false;
    } 
    public void spawnEndGameDiamonds(int amount)
    {
        HapticManager.instance.playTheSoftHaptics();
        panel.SetActive(false);
        nextButton.SetActive(false);
        restartButton.SetActive(false);

        int amountToSpawn = amount+InGameDiamondAmount;
        InGameDiamondAmount = 0;
        if (amount > 50)
        {
            amountToSpawn = 50;
            PlayerPrefs.SetInt("DIAMONDS", PlayerPrefs.GetInt("DIAMONDS") +( amount-50));
        }

        for (int i = 0; i < amountToSpawn; i++)
        {
            GameObject go = Instantiate(flyingDiamond, flyingDiamond.transform.parent);
            go.transform.position = new Vector3(flyingDiamond.transform.position.x + Random.Range(coinMin, coinMax), flyingDiamond.transform.position.y + Random.Range(coinMin, coinMax), 0);
            go.SetActive(true);
        }
       // AudioManager.instance.playMyClip(AudioManager.instance.fiveXCoin);
    }

    public int returnTheDiamonds()
    {
        return multiplyer;

    }
    public void setTheMultiplierFactor(int amount)
    {

        multiplyer = amount;

    }
    public int returnTheMultiplyX()
    {
        return multiplyer;

    }

    public void AddIngameDiamond(int amount)
    {
        InGameDiamondAmount += amount;
        diamondCollectedText.text = "+" + (InGameDiamondAmount + diamonds);
        SpawnIngameDiamond();
    }
    public void setTheDiamondsAmount_EndGame()
    {
        diamondCollectedText.text = "+" + returnTheDiamonds();
    }

    private void FixedUpdate()
    {
        totalDiamondsText.text = "" + (PlayerPrefs.GetInt("DIAMONDS") + InGameDiamondAmount);
    }
}
