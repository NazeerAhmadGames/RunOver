using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float followSpeed;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector3.Lerp(transform.position, target.position - offset, followSpeed * Time.deltaTime);
    }
}
