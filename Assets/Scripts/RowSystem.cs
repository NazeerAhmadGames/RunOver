using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSystem : MonoBehaviour
{
    [SerializeField] private float roadWidth;

    private float maxRight, maxLeft,startingPos;
    void Start()
    {

        maxRight =roadWidth- transform.position.x;
        maxLeft= roadWidth+transform.position.x;
    }

    void Update()
    {
        updateWhoFollowWho();
    }

    public void updateWhoFollowWho()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i>0)
            {
                transform.GetChild(i).GetComponent<TheCharacter>().setFollowTarget(transform.GetChild(i-1));
            }
        }
    }

    public float returnMaxLeft()
    {
        return maxLeft;
    }
    public float returnMaxRight()
    {
        return maxRight;
    }
    
}
