﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("Level 2"); //En måde
        SceneManager.LoadScene(1); //En anden måde
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //En anden måde (nuværende scene index + 1)
    }
}
