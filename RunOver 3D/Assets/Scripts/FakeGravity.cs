using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float fakeGravity = 10f;
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.up * Physics.gravity.y * (fakeGravity - 1) * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void Start()
    {
        if (rb==null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }
}
