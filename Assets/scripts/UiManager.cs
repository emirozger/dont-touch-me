using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    public GameObject pausemenuscreen;


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void paused()
    {
        pausemenuscreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void resume()
    {
        pausemenuscreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void reloadscene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
