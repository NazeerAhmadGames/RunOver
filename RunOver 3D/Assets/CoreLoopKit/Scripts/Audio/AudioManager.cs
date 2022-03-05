using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MoreMountains.NiceVibrations;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource fxSource;

    public static AudioManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


    }
    public void playMyClip(AudioClip clip)
    {
        fxSource.PlayOneShot(clip);
    }
   

}
