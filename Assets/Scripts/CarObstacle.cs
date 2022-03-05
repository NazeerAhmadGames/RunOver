using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;



public class CarObstacle : MonoBehaviour
{
    [SerializeField] private GameObject shatteredObject;
    [SerializeField] private Rigidbody[] allPieces;
    [SerializeField] private Vector3 explosionForceMin,explosionForceMax;
    [SerializeField] private GameObject explosion;
 
    public void OnDestroyTheCar()
    {
        shatteredObject.transform.parent = null;
        shatteredObject.SetActive(true);
        
        Vector3 explosionPos = transform.position;
        foreach (Rigidbody rb in allPieces)
        {
            Vector3 randomForce = new Vector3(UnityEngine.Random.Range(explosionForceMin.x, explosionForceMax.x),
                UnityEngine.Random.Range(explosionForceMin.y, explosionForceMax.y),
                UnityEngine.Random.Range(explosionForceMin.z, explosionForceMax.z));
                rb.AddForce(randomForce,ForceMode.Impulse);
                rb.AddTorque(randomForce/3,ForceMode.Impulse);

                rb.transform.DOScale(Vector3.one / 10, .6f).SetDelay(1.5f);
        }

        Destroy(shatteredObject,3);
        Destroy(gameObject);
    }
}
