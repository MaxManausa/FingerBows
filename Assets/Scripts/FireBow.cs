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
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
        arrowRb.AddForce(arrowSpawnPos.forward * arrowForce, ForceMode.Impulse);
        Debug.Log("hi!!!!!!!");
    }

    public void ReenableArrow()
    {
        fakeArrow.SetActive(true);
    }
}
