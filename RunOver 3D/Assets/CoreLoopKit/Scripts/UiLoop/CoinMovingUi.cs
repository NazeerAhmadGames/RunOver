using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class CoinMovingUi : MonoBehaviour
{
    public Transform toTransform;

    public float speed;

    public float delay;

    public bool canMove;

    private  bool isDead;

    public bool EndGameDiamond = true;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(delayToMove());
    }
    IEnumerator delayToMove()
    {
        yield return new WaitForSeconds(delay);
        canMove = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, toTransform.position, speed * Time.deltaTime);
        }

        if ((transform.position - toTransform.position).magnitude<=5f && !isDead)
        {
            isDead = true;

            if (EndGameDiamond)
            {
                PlayerPrefs.SetInt("DIAMONDS", PlayerPrefs.GetInt("DIAMONDS") + 1);
            }

          //  HapticManager.instance.playTheSoftHaptics();
            Destroy(this.gameObject);
        }
    }
}
