using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro counterText;

    [SerializeField] private Transform counter;

    [SerializeField] private CrowdSystem crowdSystem;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayedCountUpdate());

    }

    // Update is called once per frame
    void Update()
    {
        if (crowdSystem.firstRow!=null)
        {
            transform.position = new Vector3(crowdSystem.firstRow.transform.position.x, transform.position.y,
                crowdSystem.firstRow.transform.position.z);
        }

    }
    IEnumerator delayedCountUpdate()
    {
        yield return new WaitForSeconds(.2f);
        if (FinishLine.instance.returnIfCrossed())
        {
            gameObject.SetActive(false);
        }
        else
        {
            counterText.text = "" + crowdSystem.GetComponentsInChildren<TheCharacter>().Length;
            StartCoroutine(delayedCountUpdate());

        }
    }
}
