using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public bool Paused = false;
    public GameObject PauseMenuUI;
    public GameObject UI;
    // Update is called once per frame
    public void OnPauseClick()
    {
        Pause();
    }


   void Pause()
    {
        PauseMenuUI.SetActive(true);
        UI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Paused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Paused = false;
    }
}
