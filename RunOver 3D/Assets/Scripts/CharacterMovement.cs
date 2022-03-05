using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         myAnimator.SetBool("Idle",false);

        }
      

      else  if (Input.GetMouseButton(0))
        {
            transform.position+=Vector3.forward*moveSpeed*Time.deltaTime;
        }
        
       else if (Input.GetMouseButtonUp(0))
        {
            myAnimator.SetBool("Idle",true);
        }
    }
   
}
