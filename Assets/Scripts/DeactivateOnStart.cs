using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeactivateOnStart : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> gameObjects;

    public int arrowsFired;
    void Start()
    {
        foreach(var gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
