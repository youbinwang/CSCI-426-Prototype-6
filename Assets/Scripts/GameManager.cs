using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.Feedbacks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public bool ifInvisible = false;
    public float invisibleTime;
    public GameObject player;

    public int health = 3;
    public int score = 0;
    public MMF_Player bgm;

    public TextMeshProUGUI text;
     public GameObject backText;

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

    /*    if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadNextScene(1);
        }*/

       /* if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
        }*/

      /*  if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadNextScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LoadNextScene(0);
        }*/
    }

    void LoadNextScene(int index)
    {
      
        SceneManager.LoadScene(index);
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
        //Time.timeScale = 0;
       /* Destroy(player);
        text.text = "GAME END!";
        backText.SetActive(true);*/
    }
}
