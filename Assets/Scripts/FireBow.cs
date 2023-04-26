using Microsoft.MixedReality.Toolkit.Subsystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class FireBow : MonoBehaviour
{
    [SerializeField] private GameObject arrowSpawnPoint;
    [SerializeField] public Animator bowAnimation;
    [SerializeField] public GameObject fakeArrow;
    [SerializeField] public TMP_Text numberOfArrowsFired;

    [SerializeField] public AudioSource arrowAudioSource;
    [SerializeField] public AudioClip arrowWhooshSound;

    public float fireRate = 0.5f;
    public GameObject arrowPrefab;
    public float arrowForce = .1f;
    

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
        
        arrowsFired = arrowsFired + 1;
        numberOfArrowsFired.text = ("Arrows Fired: " + arrowsFired);
        Destroy(arrow, 5f);
        Debug.Log("hi!!!!!!!");
        PlayArrowSound(arrowWhooshSound);
    }

    public void ReenableArrow()
    {
        fakeArrow.SetActive(true);
    }

    public void PlayArrowSound(AudioClip arrowWhooshSound)
    {
        arrowAudioSource.clip = arrowWhooshSound;
        arrowAudioSource.Play();
    }
}