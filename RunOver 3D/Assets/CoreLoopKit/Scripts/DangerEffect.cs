using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerEffect : MonoBehaviour
{
    public static DangerEffect instance;
    private float timeToFill;
    private bool canFill;

    private Image myImage;
    [SerializeField] private GameObject textOutOFMoves;

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        myImage = GetComponent<Image>();
        myImage.enabled = false;
    }
    void Update()
    {
        if (canFill)
        {
            myImage.fillAmount += 1.0f / timeToFill * Time.deltaTime;
        }
    }

    public void startingTheEffect(float duration)
    {
        if (canFill == false)
        {
            timeToFill = duration;
            myImage.fillAmount = 0;
            myImage.enabled = true;
            canFill = true;
            textOutOFMoves.SetActive(true);
        }
    }
    public void stopTheEffect()
    {
        if (canFill)
        {
            canFill = false;
            myImage.enabled = false;
            textOutOFMoves.SetActive(false);

        }
    }
}
