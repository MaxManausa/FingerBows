using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentChild : MonoBehaviour
{
    [SerializeField] private Transform child;

    private void Start()
    {
        //Give it a second to set
        Invoke("Adoption",3f);
    }

    private void Adoption()
    {
        // Unparent the child object
        child.SetParent(null);
    }
}
