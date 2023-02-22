using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject gameOverUILose;
    public GameObject gameOverUIWin;
    
    public void GameOverLose()
    {
        gameOverUILose.SetActive(true);
    }

    public void GameOverWin()
    {
        gameOverUIWin.SetActive(true);
    }
    
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
