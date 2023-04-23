using Microsoft.MixedReality.Toolkit.Subsystems;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class FireBow : MonoBehaviour
{
    [SerializeField] private GameObject arrowSpawnPoint;
    [SerializeField] public Animator bowAnimation;
    [SerializeField] public GameObject fakeArrow;

    public float fireRate = 0.5f;
    public GameObject arrowPrefab;
    public float arrowForce = .1f;


    public void OnButtonSmash()
    {
        DrawBack();
        Invoke("ShootArrow",.4f);
        Invoke("RenewArrow",.8f);
    }

    public void UnlimitedArrowLaunch()
    {
        float i = 1f;
        Invoke("OnButtonSmash", i);
        Invoke("OnButtonSmash", i += 1);
        Invoke("OnButtonSmash", i += 1);
        Invoke("OnButtonSmash", i += 1);
        Invoke("OnButtonSmash", i += 1);
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

    public void RenewArrow()
    {
        fakeArrow.SetActive(true);
    }
}
