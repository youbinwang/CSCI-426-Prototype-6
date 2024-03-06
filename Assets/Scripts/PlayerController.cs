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

    public GameObject enemyParticleSystem;
    public GameObject coinParticleSystem;
    
    public AudioClip enemyHitSound;
    public AudioClip coinCollectSound;
    
    private AudioSource audioSource;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
        
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
            GameObject psInstance = Instantiate(enemyParticleSystem.gameObject, collision.transform.position, Quaternion.identity) as GameObject;
            psInstance.GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(enemyHitSound);
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Coin")
        {
            gameManager.ChangeScore(1);
          /*  GameObject psInstance = Instantiate(coinParticleSystem.gameObject, collision.transform.position, Quaternion.identity) as GameObject;
            psInstance.GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(coinCollectSound);*/
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
