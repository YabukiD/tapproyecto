﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeCherry : MonoBehaviour
{
    public GameManager manager;
    public GameObject[] cherries;
    public Text coinsText;
    // Update is called once per frame
    void Update()
    {
        cherries = GameObject.FindGameObjectsWithTag("Cherry"); 
        if(cherries.Length==0)
        {
            manager.FinishLevel();
        }
        //updateIO
        coinsText.text = "x" + cherries.Length;

    }
}
