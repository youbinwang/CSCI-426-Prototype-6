using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    public int health = 3;
    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateHealthUI();
        UpdateScoreUI();
    }
    
    public void Update()
    {
        if (health == 0)
        {
            GameEnd();
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        UpdateHealthUI();
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateHealthUI()
    {
        healthText.text = health.ToString("0");
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString("00");
    }

    void GameEnd()
    {
        
    }
}