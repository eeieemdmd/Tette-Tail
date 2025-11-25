using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    public void GameScene()
    {
        SceneManager.LoadScene("Tetris");
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
