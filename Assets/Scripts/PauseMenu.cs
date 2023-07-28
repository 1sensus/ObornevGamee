using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool Game_is_paused = false;
    public GameObject PauseMenuUI;

    public void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Game_is_paused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }

            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        Game_is_paused = false;
    }
    void Pause()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
        Game_is_paused = true;
    }
    public void TryAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Scene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_menu");
    }

}