using System.Runtime.CompilerServices;
using UnityEngine;

public class FreezeOnCollision : MonoBehaviour
{
    private Rigidbody arrowRigidbody;
    private void Start()
    {
        arrowRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() == collision.rigidbody.CompareTag("Target"))
        {
                arrowRigidbody.isKinematic = true;
                arrowRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                Debug.Log("arrow collided with" + name);
        }
    }
}
