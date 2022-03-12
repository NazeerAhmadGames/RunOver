using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionEffect : MonoBehaviour
{
    public static SlowMotionEffect instance;
    // Start is called before the first frame update
    public float slowMotionTimeScale = 0.5f;
    public bool slowMotionEnabled = false;

    private void Awake()
    {
        instance = this;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //Find all AudioSources in the Scene and save their default pitch values
        /*
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        audioSources = new AudioSourceData[audios.Length];

        for (int i = 0; i < audios.Length; i++)
        {
            AudioSourceData tmpData = new AudioSourceData();
            tmpData.audioSource = audios[i];
            tmpData.defaultPitch = audios[i].pitch;
            audioSources[i] = tmpData;
        }
*/
       
    }

    // Update is called once per frame
    void Update()
    {
        //Activate/Deactivate slow motion on key press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            slowMotionEnabled = !slowMotionEnabled;
            SlowMoEffect(slowMotionEnabled);
        }
    }

  public  void SlowMoEffect(bool enabled)
    {
        if (enabled)
        {
            Time.timeScale = .3f;
        }
        else
        {
            Time.timeScale = 1f;
        }
      

        StartCoroutine(delayedNormal());
    }

    IEnumerator delayedNormal()
    {
        yield return new WaitForSeconds(.2f);
        SlowMoEffect(false);
    }

}
