using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    public static CrowdSystem instance;
    public RowSystem firstRow => rows[_firstRowIndex];
    [SerializeField] private float leftRightMoveFactor;

    [SerializeField] private RowSystem rowSystemPrefab;
    private bool canMoveForward = true;
    private List<TheCharacter> characters = new List<TheCharacter>();
    public List<RowSystem> rows = new List<RowSystem>();
    private int _firstRowIndex;
    private float _reArrangeTimer = 0;
    private bool rowsModified = false;

    private void Awake()
    {
        instance = this;
        CalculateFirstRow();
    }

    public void RemoveCharacter(TheCharacter character, RowSystem charRow)
    {
        if (characters.Contains(character))
        {
            charRow.RemoveChar(character);
            characters.Remove(character);
            _reArrangeTimer = 2;
            rowsModified = true;
        }
    }

    public void AddCharacter(TheCharacter character)
    {
        characters.Add(character);
        GetEmptyRow().AddChar(character);
    }

    public void Swerve(float movementX)
    {
      //  firstRow.transform.localPosition += new Vector3(movementX, 0, 0);
        Vector3 newPos  = firstRow.transform.position+new Vector3( movementX, 0, 0);
           
        firstRow.transform.position = new Vector3(Mathf.Clamp(newPos.x, -leftRightMoveFactor, leftRightMoveFactor),
            firstRow.transform.position.y,      firstRow.transform.position.z );
    }

    public void ForwardMove(float speed)
    {
        foreach (var row in rows)
        {
            row.transform.position += new Vector3(0, 0, Time.deltaTime * speed);
        }
    }

    private void Update()
    {
        UpdateRowPosses();
        CalculateFirstRow();
        if (rowsModified)
        {
            _reArrangeTimer -= Time.deltaTime;
            if (_reArrangeTimer <= 0)
            {
                rowsModified = false;
                ReArrangeRows();
            }
        }
    }

    private void LateUpdate()
    {
        ControlForLevelFail();
    }

    private RowSystem GetEmptyRow()
    {
        RowSystem emptyRow = null;
        for (int i = 0; i < rows.Count; i++)
        {
            if (!rows[i].AmIFull)
            {
                emptyRow = rows[i];
                break;
            }
        }

        if (emptyRow == null)
        {
            RowSystem rs = Instantiate(rowSystemPrefab, transform);
            rs.transform.position = rows[0].transform.position - new Vector3(0, 0, rows.Count);
            rows.Add(rs);
            emptyRow = rs;
        }

        return emptyRow;
    }


    private void UpdateRowPosses()
    {
        if (rows.Count == 0)
            return;

        for (int i = _firstRowIndex+1; i < rows.Count; i++)
        {
            Vector3 lpos = rows[i].transform.localPosition;
            lpos.x = Mathf.Lerp(lpos.x, rows[i - 1].transform.localPosition.x, Time.deltaTime * 14f);
            rows[i].transform.localPosition = lpos;
        }
    }

    private void CalculateFirstRow()
    {
        for (int i = 0; i < rows.Count; i++)
        {
            if (rows[i].charcount > 0)
            {
                _firstRowIndex = i;
                return;
            }
        }

        _firstRowIndex = 0;
    }

    private void ReArrangeRows()
    {
        while (rows.Count > 1)
        {
            if (rows[0].charcount == 0)
            {
                var destroyRow = rows[0].gameObject;
                rows.RemoveAt(0);
                Destroy(destroyRow);
            }
            else
            {
                break;
            }
        }

        foreach (var rowSystem in rows)
        {
            rowSystem.ClearChars();
        }

        List<TheCharacter> charBuffer = new List<TheCharacter>();
        foreach (var character in characters)
        {
            charBuffer.Add(character);
        }
        characters.Clear();
        foreach (var character in charBuffer)
        {
            AddCharacter(character);
        }

        CalculateFirstRow();
    }

    private void ControlForLevelFail()
    {
        foreach (var rowSystem in rows)
        {
            if (rowSystem.charcount>0)
            {
                return;
                
            }
        }
        PlayerController.instance.LevelEnd(true);
    }
}