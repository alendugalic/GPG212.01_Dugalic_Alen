using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    TextMeshProUGUI scoreText;
    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        scoreText.text = " Score: " + scoreValue;
    }
    public void AddScore(int amount)
    {
        scoreValue += amount;
    }
}
