using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [SerializeField] private Transform characterToMove;
    [SerializeField] private int crowdSizeToAdd;

     private RowSystem[] allRows;
     private List<Transform> charactersToMove=new List<Transform>();
    private SwerveInputSystem swerveInputSystem;
    private int totalRows,currentDestroyRowIndex;
    
    [SerializeField] private float horizontalSpeed,forwardSpeed,leftMoveFactor;

    public static CrowdSystem instance;

    private bool canMoveForward = true;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
        allRows = GetComponentsInChildren<RowSystem>();
            StartCoroutine(delayedAddCrowd(crowdSizeToAdd));
            totalRows = allRows.Length;

    }
    void OnEnable()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
       
        FindGroupOfLeaders();
        SwerveLeftRight();

        if (canMoveForward)
        {
            transform.position+=Vector3.forward*forwardSpeed*Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(delayedAddCrowd(1));
        }
    }

    private void FindGroupOfLeaders()
    {
        for (int i = 0; i < allRows.Length; i++)
        {
            if (allRows[i].transform.childCount > 0)
            {
                if (charactersToMove.Count < allRows.Length)
                {
                    charactersToMove.Add(null);
                }

                charactersToMove[i] = (allRows[i].transform.GetChild(0));
            }
        }
    }

    private void SwerveLeftRight()
    {
        if (charactersToMove.Count<=0)
        {
            return;
        }
        for (int i = 0; i < charactersToMove.Count; i++)
        {
           
            Transform currentCharacterToMove = charactersToMove[i];
            if (currentCharacterToMove==null)
            {
                return;
            }
            
            float movementX = (swerveInputSystem.MoveFactorX * horizontalSpeed) * Time.deltaTime;

            Vector3 newPos = currentCharacterToMove.position + new Vector3(movementX, 0, 0);
            Vector2 currentClamping =
                new Vector2(currentCharacterToMove.parent.GetComponent<RowSystem>().returnMaxLeft(),
                    currentCharacterToMove.parent.GetComponent<RowSystem>().returnMaxRight());
            currentCharacterToMove.position = new Vector3(Mathf.Clamp(newPos.x, -currentClamping.x, currentClamping.y),
                currentCharacterToMove.position.y, currentCharacterToMove.position.z);
        }
    }

    IEnumerator delayedAddCrowd(int size)
    {
        int currentlySpawned = 0;

        for (int i = 0; i < size; i++)
        {
            if (currentlySpawned<size)
            {
                foreach (RowSystem rs in allRows)
                {
                   yield return new WaitForSeconds(.01f);

                   GameObject spawnedCharacter = Instantiate(rs.transform.GetChild(rs.transform.childCount-1).gameObject,rs.transform);
                   spawnedCharacter.name = "Character " + "(" + i + ")";
                   currentlySpawned++;

                }
            }
        }
    }

    public void removeOneCharacter()
    {
        Destroy(allRows[currentDestroyRowIndex].transform.GetChild(allRows[currentDestroyRowIndex].transform.childCount-1).gameObject);
        currentDestroyRowIndex++;
        if (currentDestroyRowIndex>=totalRows)
        {
            currentDestroyRowIndex = 0;
        }
    }

    public void setIfCanMove(bool can)
    {
        canMoveForward = can;
    }
}
