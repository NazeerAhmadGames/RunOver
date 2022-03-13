using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RowSystem : MonoBehaviour
{
    public bool AmIFull => characters.Count >=nests.Length ;
    public int charcount => characters.Count;
    public Transform[] nests;
    
    private List<TheCharacter> characters = new List<TheCharacter>();
    

    public void AddChar(TheCharacter character)
    {
        Transform selectedNest = nests[characters.Count];
        characters.Add(character);
        character.transform.SetParent(selectedNest);
        character.transform.DOLocalMove(Vector3.zero, 0.5f);
        character.myRow = this;
    }

    public void RemoveChar(TheCharacter character)
    {
        if (characters.Contains(character))
        {
            characters.Remove(character);  
        }
    }


    public void ClearChars()
    {
        characters.Clear();
    }
}
