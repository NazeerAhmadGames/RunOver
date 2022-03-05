using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventPlay : MonoBehaviour
{
    public void playTheClip(AudioClip clip)
    {
        AudioManager.instance.playMyClip(clip);
    }
}
