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
    [SerializeField] private GameObject fallSfx;
    [SerializeField] private float velocityToPlaySfx=5;
    private int bonusAmount;
    private bool velocityCheckCoolDown,landingCooledDown=true;


    public static EndingCar instance;
    private bool hasStopped;
    void Awake()
    {
        instance = this;
    }
    void FixedUpdate()
    {
        if (hasKicked)
        {
            if (rb.velocity.magnitude<3 &&velocityCheckCoolDown &&!hasStopped)
            {
                hasStopped = true;
                CoreLoopUi.instance.onWinningGame();
                CameraFollowCharacter.instance.showConfetti();
                DiamondRewardSystem.instance.setTheDiamondsAmount_EndGame(bonusAmount);
            }
        }
    }

    IEnumerator checkForVelocityDelay()
    {
        yield return new WaitForSeconds(1);
        velocityCheckCoolDown = true;

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<TheCharacter>() && !hasKicked)
        {
            hasKicked = true;
            PlayerController.instance.setIfCanMove(false);
            EndingGiant.instance.playGiantKickAnimation();
            StartCoroutine(delayedKickForce());
            HapticManager.instance.playTheLightHaptics();

        }
        
        if (col.gameObject.GetComponent<EndingTile>())
        {
            col.gameObject.GetComponent<EndingTile>().landedOn();
            
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > velocityToPlaySfx &&landingCooledDown)
        {
            landingCooledDown = false;
            GameObject spawnedSfx = Instantiate(fallSfx);
            spawnedSfx.SetActive(true);
            Destroy(spawnedSfx,2);
            StartCoroutine(addlandingSfxCoolDown());
            HapticManager.instance.playTheLightHaptics();

        }
           
    }

    IEnumerator addlandingSfxCoolDown()
    {
        yield return new WaitForSeconds(.6f);
        landingCooledDown = true;
    }

    IEnumerator delayedKickForce()
    {
        yield return new WaitForSeconds(.2f);

        SlowMotionEffect.instance.SlowMoEffect(true);

        yield return new WaitForSeconds(.5f);
        hitVFx.transform.parent = null;
        hitVFx.SetActive(true);
        Destroy(hitVFx,2);
        Camera.main.GetComponent<DOTweenAnimation>().DORestartById("Shake");
        yield return new WaitForSeconds(.2f);
        CameraFollowCharacter.instance.followFlyingEndingObject(transform);
        rb.isKinematic = false;
        forceVector = new Vector3(forceVector.x, forceVector.y,
            forceVector.z * EndingGiant.instance.returnTheTotalCount());
        rb.AddForce(forceVector,ForceMode.Impulse);
        rb.AddTorque(torqueVector,ForceMode.Impulse);

        StartCoroutine(checkForVelocityDelay());
    }

    public void updateCurrentBonusAmount(int value)
    {
        bonusAmount = value;
    }
}
