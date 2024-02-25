using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceLine : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 bounceDirection = collision.contacts[0].normal;
                rb.velocity = bounceDirection * bounceForce;
            }
        }
    }
}
