using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingGiant : MonoBehaviour
{
    public static EndingGiant instance;
    private Transform giant;
    private int totalCount;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void mergeAllCharacters(TheCharacter leader)
    {
        CameraFollowCharacter.instance.updateTarget(leader.transform);
        giant = leader.transform;
        leader.setMeAsGiantLeader(true);
        foreach (TheCharacter c in GetComponentsInChildren<TheCharacter>())
        {
            c.mergeIntoGiant(leader);
        }
    }

    public void increaseGiantSize()
    {
        giant.localScale += Vector3.one / 10;
        totalCount++;
    }

    public void playGiantKickAnimation()
    {
        giant.GetComponent<Animator>().Play("Kick");
    }

    public int returnTheTotalCount()
    {
        return totalCount;
    }
}
