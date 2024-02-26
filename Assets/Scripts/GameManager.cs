using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.Feedbacks;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public bool ifInvisible = false;
    public float invisibleTime;

    public int health = 3;
    public int score = 0;
    public MMF_Player bgm;

    private void Awake()
    {
      /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/

        UpdateHealthUI();
        UpdateScoreUI();
    }

    private void Start()
    {
        bgm.PlayFeedbacks();
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
        if (!ifInvisible)
        {
            ifInvisible = true;
            health += amount;
            UpdateHealthUI();
            Invoke("SetIfInvisibleFalse", invisibleTime);
        }
     
    }

    void SetIfInvisibleFalse()
    {
        ifInvisible = false;
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
        Time.timeScale = 0;
        //
    }
}
