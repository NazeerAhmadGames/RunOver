using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitchSound : MonoBehaviour
{

    public bool destroyWhenDone = true;
    [Range(0.01f, 10f)]
    public float pitchRandomMultiplier = 1f;

    // Use this for initialization
    void Start()
    {
        //Spawn the sound object
        AudioSource m_Source = GetComponent<AudioSource>();

       

        //Multiply pitch
        if (pitchRandomMultiplier != 1)
        {
            if (Random.value < .5)
                m_Source.pitch *= Random.Range(1 / pitchRandomMultiplier, 1);
            else
                m_Source.pitch *= Random.Range(1, pitchRandomMultiplier);
        }

        //Set lifespan if true
        if (destroyWhenDone)
        {
            float life = m_Source.clip.length / m_Source.pitch;
            Destroy(gameObject, life);
        }

    }
}//End of class
