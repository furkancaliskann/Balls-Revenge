using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool gamePaused;
    public GameObject pauseMenu;

    public GameObject pausePanel, settingsPanel;


    public void OpenPauseMenu()
    {
        Time.timeScale = 0.0f;
        gamePaused = true;

        OpenPanel(pauseMenu);
        OpenPanel(pausePanel);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        gamePaused = false;
    }

    public void OpenSettings()
    {
        OpenPanel(settingsPanel);
    }

    public void OpenPause()
    {
        OpenPanel(pausePanel);
    }

    void OpenPanel(GameObject panel)
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        panel.SetActive(true);
    }
}
