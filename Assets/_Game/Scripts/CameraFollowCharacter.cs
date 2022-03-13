using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraFollowCharacter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject confetti;
    [SerializeField] private float followSpeed;

    private Vector3 offset;

    private Vector3 targetPos;

    public static CameraFollowCharacter instance;

    private bool canFollowEndingObject;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
        targetPos = PlayerController.instance.camFollowTarget.position - offset;
    }

    // Update is called once per frame
    void Update()
    {

        if (!canFollowEndingObject)
        {
           // Vector3 newpos = new Vector3(transform.position.x, PlayerController.instance.camFollowTarget.position.y, PlayerController.instance.camFollowTarget.position.z) - offset;
            Vector3 newpos = PlayerController.instance.camFollowTarget.position- offset;
            newpos.x = Mathf.Clamp(newpos.x, -4f, 4f);
            newpos.x = Mathf.Lerp(transform.position.x, newpos.x, Time.deltaTime*2);
            
            if (newpos.z > targetPos.z)
                targetPos = newpos;
            transform.position = Vector3.Lerp(transform.position,targetPos , followSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position,target.transform.position-offset-new Vector3(0,0,10) , followSpeed * Time.deltaTime);

        }
      
        
    }

    public void updateTarget(Transform t)
    {
        target = t;
    }

    public void followFlyingEndingObject(Transform t)
    {
        target = t;
        canFollowEndingObject = true;

    }

    public void showConfetti()
    {
        confetti.SetActive(true);
        Destroy(confetti,2);
    }
}
