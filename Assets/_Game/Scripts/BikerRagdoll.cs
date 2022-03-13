using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerRagdoll : MonoBehaviour
{
   [SerializeField] private CharacterJoint[] allJoints;

   [SerializeField] private Vector3 forceToAdd;

   [SerializeField] private PhysicMaterial bouncyMat;
    // Start is called before the first frame update
    void OnEnable()
    {
        allJoints = GetComponentsInChildren<CharacterJoint>();
        transform.parent
            = null;

        foreach (CharacterJoint cj in allJoints)
        {
            cj.projectionAngle = 35;
            cj.projectionDistance = 0.1f;
            cj.GetComponent<Rigidbody>().AddForce(forceToAdd,ForceMode.Impulse);
            cj.gameObject.AddComponent<FakeGravity>();
            if (cj.GetComponent<Collider>()!=null)
            {
                cj.GetComponent<Collider>().material = bouncyMat;
            }
          
        }
        
        Destroy(gameObject
        ,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
