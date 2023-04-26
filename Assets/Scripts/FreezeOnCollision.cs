using System.Runtime.CompilerServices;
using UnityEngine;

public class FreezeOnCollision : MonoBehaviour
{
    private Rigidbody arrowRigidbody;
    
    [SerializeField] public AudioSource arrowAudioSource;
    [SerializeField] public AudioClip arrowImpactSound;
    private void Start()
    {
        arrowRigidbody = GetComponent<Rigidbody>();
        arrowRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Target") ==collision.gameObject.GetComponent<Rigidbody>())
        {
                
            transform.SetParent(collision.transform);
            PlayArrowSound(arrowImpactSound);
            arrowRigidbody.isKinematic = true; 
            arrowRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("arrow collided with" + name);
        }
        else
        {
            return;
        }
    }
    
    private void PlayArrowSound(AudioClip arrowImpactSound)
    {
        arrowAudioSource.clip = arrowImpactSound;
        arrowAudioSource.Play();
    }
}
