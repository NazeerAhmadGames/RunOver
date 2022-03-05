using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartTheGame : MonoBehaviour
{
    private bool firstClick;

   [SerializeField] private GameObject startingPanel;

    void Start()
    {
        
    }

    void Update()
    {
     
        if ( (Application.platform==RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor) && Input.GetMouseButton(0)  && !EventSystem.current.IsPointerOverGameObject())
        {
            hideTutorial();
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                hideTutorial();
            }
        }
    
       
    }


    public void hideTutorial()
    {
        /*
        if (!firstClick  && PlayerState.instance!=null)
        {
            firstClick = true;
            startingPanel.SetActive(false);
            PlayerState.instance.onStartingPlaying();
        }
        */
    }

    public void onPlayButton()
    {
        //PlayerControl.instance.playButtonPressedNow();
    }
}
