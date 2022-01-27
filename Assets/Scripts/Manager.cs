using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public BallScript scriptBall;
    public GameObject failedPanel;
    public GameObject passPanel;

    void Start()
    {
        
    }

    public void toNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void levelCompleted()
    {
        passPanel.SetActive(true);
    }
    public void levelFailed()
    {
        failedPanel.SetActive(true);
    }
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
