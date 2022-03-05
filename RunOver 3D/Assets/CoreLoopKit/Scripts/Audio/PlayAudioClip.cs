using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private float delay;

    void OnEnable()
    {
        StartCoroutine(delayedPlay());
    }
     IEnumerator delayedPlay()
    {
        yield return new WaitForSeconds(delay);
        playTheClip();
    }
    public void playTheClip()
    {
        if(audioClip!=null)
        AudioManager.instance.playMyClip(audioClip);

    }
}
