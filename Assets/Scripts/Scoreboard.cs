using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public int score = 0;


    void Start()
    {
        GetComponent<TMP_Text>().text = "Score: " + score.ToString();
    }
    void Update()
    {
        Debug.Log("Score: " + score);
        GetComponent<TMP_Text>().text = "Score: " + score.ToString();
    }
    
    
}
