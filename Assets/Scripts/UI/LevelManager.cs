using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;
    public GameObject deathScreen;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI gameTimer;

    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        manager = this;
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);
        });
    }
    private void Update()
    {
        scoreText.text = " Score: " + score.ToString();
        gameTimer.text = " Time: " + Time.realtimeSinceStartup; //need to fix so it actually works right this is just a placeholder for now
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
