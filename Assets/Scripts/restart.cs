using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{

    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private GameObject menuPanel;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        if (!Global_Script.isPaused)
        {
            Global_Script.isPaused = true;
        }
        else
        {
            Global_Script.isPaused = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
