using Microsoft.MixedReality.Toolkit.Subsystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR;

public class FireBow : MonoBehaviour
{
    [SerializeField] private GameObject arrowSpawnPoint;
    [SerializeField] public Animator bowAnimation;
    [SerializeField] public GameObject fakeArrow;
    [SerializeField] public TMP_Text numberOfArrowsFired;

    public float fireRate = 0.5f;
    public GameObject arrowPrefab;
    public float arrowForce = .1f;
    
    [SerializeField] private AudioSource arrowAudioSource;
    [SerializeField] private AudioClip arrowWhooshSound;
    

    public int arrowsFired;

    
    public void OnButtonSmash()
    {
        DrawBack();
        Invoke("ShootArrow",.4f);
        Invoke("ReenableArrow",.8f);
    }

    public void FiveShots()
    {
        int i = 0;
        Invoke("OnButtonSmash", i += 1);
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
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
        arrowRb.AddForce(arrowSpawnPos.forward * arrowForce, ForceMode.Impulse);
        PlaySound(arrowWhooshSound);
        arrowsFired = arrowsFired + 1;
        numberOfArrowsFired.text = ("Arrows Fired: " + arrowsFired);
        Destroy(arrow, 5f);
        Debug.Log("hi!!!!!!!");
    }

    public void ReenableArrow()
    {
        fakeArrow.SetActive(true);
    }
    
    private void PlaySound(AudioClip newSound)
    {
        newSound = arrowWhooshSound;
        arrowAudioSource.Play();
    }
}