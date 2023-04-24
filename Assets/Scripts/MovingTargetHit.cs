using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetHit : MonoBehaviour
{[SerializeField] public Material hitMaterial;
    [SerializeField] private TargetController _targetController;
    [SerializeField] private Scoreboard _scoreboard;

    [SerializeField] public Material originalMaterial;
    public Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            renderer.material = hitMaterial;
            if (_targetController.enabled == true)
            {
                _scoreboard.score += 1; 
            }
            _targetController.enabled = false; 
            Debug.Log(_scoreboard.score);
        }
    }
}
