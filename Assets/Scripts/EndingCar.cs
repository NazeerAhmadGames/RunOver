using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndingCar : MonoBehaviour
{  
    private bool hasKicked;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 forceVector,torqueVector;
    [SerializeField] private GameObject hitVFx;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<TheCharacter>() && !hasKicked)
        {
            hasKicked = true;
            PlayerController.instance.setIfCanMove(false);
            EndingGiant.instance.playGiantKickAnimation();
            StartCoroutine(delayedKickForce());
            SlowMotionEffect.instance.SlowMoEffect(true);
        }
        
        if (col.gameObject.GetComponent<EndingTile>())
        {
            col.gameObject.GetComponent<EndingTile>().landedOn();
        }
    }

    IEnumerator delayedKickForce()
    {
        yield return new WaitForSeconds(.6f);
        hitVFx.transform.parent = null;
        hitVFx.SetActive(true);
        Destroy(hitVFx,2);
        Camera.main.GetComponent<DOTweenAnimation>().DORestartById("Shake");
        yield return new WaitForSeconds(.2f);
        CameraFollowCharacter.instance.followFlyingEndingObject(transform);
        rb.isKinematic = false;
        print("total giant Count was "+ EndingGiant.instance.returnTheTotalCount());
        forceVector = new Vector3(forceVector.x, forceVector.y,
            forceVector.z * EndingGiant.instance.returnTheTotalCount());
        rb.AddForce(forceVector,ForceMode.Impulse);
        rb.AddTorque(torqueVector,ForceMode.Impulse);
    }
}
