using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private CrowdSystem crowdSystem;
    public TheCharacter charPrefab;
    public Transform camFollowTarget => crowdSystem.firstRow.transform;
    [SerializeField] private float horizontalSpeed, forwardSpeed;
    private SwerveInputSystem swerveInputSystem;
    [SerializeField] private GameObject dummyCharacter;

    private bool canMove=true;

    private void Awake()
    {
        instance = this;
        swerveInputSystem = GetComponent<SwerveInputSystem>();
        dummyCharacter.SetActive(false);
 
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            TheCharacter ch = Instantiate(charPrefab, crowdSystem.rows[0].transform.position, Quaternion.identity);
                
            AddCharacter(ch);
        }
    }

    private void Update()
    {
  
        if (canMove)
        {
            crowdSystem.ForwardMove(forwardSpeed); 
            crowdSystem.Swerve((swerveInputSystem.MoveFactorX * horizontalSpeed*Time.deltaTime));
        }
      

        if (Input.GetKeyDown(KeyCode.S))
        {
            addMoreCharacters(10);
        }
    }

    public void addMoreCharacters(int number)
    {
        for (int i = 0; i < number; i++)
        {
            TheCharacter ch = Instantiate(charPrefab, crowdSystem.rows[0].transform.position, Quaternion.identity);
                
            AddCharacter(ch);
        }
    }

    public void AddCharacter(TheCharacter character)
    {
        crowdSystem.AddCharacter(character);
    }

    public void LevelEnd(bool fail)
    {
        if (fail)
        {
            enabled = false;
            crowdSystem.enabled = false;
          CoreLoopUi.instance.onLoosingGame();

        }
    }

    public void setIfCanMove(bool can)
    {
        canMove = can;
    }
}