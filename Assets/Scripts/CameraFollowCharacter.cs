using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float followSpeed;

    private Vector3 offset;

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
        targetPos = PlayerController.instance.camFollowTarget.position - offset;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newpos = new Vector3(transform.position.x, PlayerController.instance.camFollowTarget.position.y,
            PlayerController.instance.camFollowTarget.position.z) - offset;
        if (newpos.z > targetPos.z)
            targetPos = newpos;
        transform.position = Vector3.Lerp(transform.position,targetPos , followSpeed * Time.deltaTime);
        
    }
}
