using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;
    private int Score {get {return _score; } }
    private int _highScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentScoreText.text = _score.ToString();
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void UpdateHighScore()
    {   
        if(_score > PlayerPrefs.GetInt("HighScore"))
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }   

    public void ShowHighScore()
    {
        _finalScoreText.text = _score.ToString();
        _highScoreText.text = _highScore.ToString();
    }
}
