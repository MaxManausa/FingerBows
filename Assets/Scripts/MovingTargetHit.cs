using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetHit : MonoBehaviour
{
    [SerializeField] public Material hitMaterial;
    [SerializeField] private TargetController _targetController;
    [SerializeField] private Scoreboard _scoreboard;

    [SerializeField] public Material originalMaterial;
    public Renderer renderer;
    
    [SerializeField] public AudioSource arrowAudioSource;
    [SerializeField] public AudioClip arrowHitTargetSound;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = originalMaterial;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            renderer.material = hitMaterial;
            if (_targetController.enabled == true)
            {
                _scoreboard.score += 1; 
                PlayArrowSound(arrowHitTargetSound);
            }
            _targetController.enabled = false;
            Debug.Log(_scoreboard.score);
            Invoke("TargetBackOn",6f);
        }
    }

    void TargetBackOn()
    {
        //turns the target back on
        renderer.material = originalMaterial;
        _targetController.enabled = true;
    }
    
    public void PlayArrowSound(AudioClip arrowHitTargetSound)
    {
        arrowAudioSource.clip = arrowHitTargetSound;
        arrowAudioSource.Play();
    }
}
