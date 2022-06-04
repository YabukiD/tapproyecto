using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeTimeTrial : MonoBehaviour
{
    public GameManager manager;
    public float levelTimer = 300f;
    public Text timeText;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (levelTimer > 0)
        {
            levelTimer = levelTimer - Time.deltaTime;//restar tiempo hasta 0
        }
        else
        {
            if (manager.isGameOver == false && manager.isLevelFinished == false) 
            {
                manager.isGameOver = true;
                manager.player.Die();
            }
        }

        timeText.text = "  " + levelTimer.ToString("F1"); 
    }
}
