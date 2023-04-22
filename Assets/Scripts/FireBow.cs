using Microsoft.MixedReality.Toolkit.Subsystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class FireBow : MonoBehaviour
{
    [SerializeField] private GameObject arrowSpawnPoint;
    [SerializeField] public Animator bowAnimation;
    [SerializeField] public GameObject fakeArrow;
    [SerializeField] public Transform fingerTransform;

    public float fireRate = 0.5f;
    public GameObject arrowPrefab;
    public float arrowForce = .1f;
    
    


    public void OnButtonSmash()
    {
        DrawBack();
        Invoke("ShootArrow",.4f);
        Invoke("ReenableArrow",.8f);
        
    }

    public void DrawBack()
    {
        bowAnimation = GetComponent<Animator>();
        bowAnimation.enabled = true;
        bowAnimation.Play("GetShotBoi");
    }

    public void ShootArrow()
    {
        fakeArrow.SetActive(false);
        Transform arrowSpawnPos = arrowSpawnPoint.transform;

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPos.position, arrowSpawnPos.rotation);
        arrow.tag = "Arrow";
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
        arrowRb.AddForce(arrowSpawnPos.forward * arrowForce, ForceMode.Impulse);
        Destroy(arrow, 4f);
        Debug.Log("hi!!!!!!!");
    }

    public void ReenableArrow()
    {
        fakeArrow.SetActive(true);
    }

    public void FingerGun()
        // When the second finger (NearInteractionModeDetector) does this transform, shoot
    {
        /*if (transform.rotation.x > 50 && transform.rotation.x < 100 
                                      && transform.rotation.y > 50 && transform.rotation.y < 100 
                                      && transform.rotation.z > 50 && transform.rotation.z < 100) */
            if(fingerTransform.rotation.x > 70)
        {
            Invoke("OnButtonSmash", 1f);
            Debug.Log("It worked");
        }
    }
}
