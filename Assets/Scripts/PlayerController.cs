using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    public GameManager gameManager;
    private Rigidbody2D rb;
    public float force;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            ApplyRandomForce(rb);
        }
    }

    void ApplyRandomForce(Rigidbody2D rb)
    {
        float randomAngle = Random.Range(0f, 360f); 
        float radian = randomAngle * Mathf.Deg2Rad; 

       
        Vector2 forceDirection = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));


        rb.velocity = forceDirection * force;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameManager.ChangeHealth(-1);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Coin")
        {
            GameManager.instance.ChangeScore(1);
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }*/
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
