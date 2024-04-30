using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _tutorialScreen;
    public static GameController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Debug.Log("GameStart");
        _tutorialScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.SetActive(true);
        ScoreCounter.instance.ShowHighScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
