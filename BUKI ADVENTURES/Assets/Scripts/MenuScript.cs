using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public static bool gameIsPaused = false;//
    public GameObject pauseMenuIU;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuIU.SetActive(false);
        Time.timeScale = 1F;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuIU.SetActive(true);
        Time.timeScale = 0F;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {


        Debug.Log("Cargando Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("00 Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del Menu...");
        Application.Quit();
    }
}
