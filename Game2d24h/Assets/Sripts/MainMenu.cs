using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartHandler()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void ExitHendler()
    {
        Application.Quit();
    }

    public void AllLevels()
    {
        SceneManager.LoadScene(1);
    }
}
