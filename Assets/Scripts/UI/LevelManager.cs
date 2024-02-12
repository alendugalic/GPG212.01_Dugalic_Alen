using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;
    public GameObject deathScreen;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;


    private void Awake()
    {
        manager = this;
    }
    private void Update()
    {
        scoreText.text = " Score: " + score.ToString();
    }
    public void GameOver() 
    {
        deathScreen.SetActive(true);
        
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void IncreaseScore(int amount) 
    {
        score += amount;
    }
}
