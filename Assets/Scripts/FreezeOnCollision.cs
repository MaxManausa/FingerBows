using System.Runtime.CompilerServices;
using UnityEngine;

public class FreezeOnCollision : MonoBehaviour
{
    private Rigidbody arrowRigidbody;
    private void Start()
    {
        arrowRigidbody = GetComponent<Rigidbody>();
        arrowRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Target") ==collision.gameObject.GetComponent<Rigidbody>())
        {
                arrowRigidbody.isKinematic = true;
                arrowRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                Debug.Log("arrow collided with" + name);
        }
        else
        {
            return;
        }
    }
}
