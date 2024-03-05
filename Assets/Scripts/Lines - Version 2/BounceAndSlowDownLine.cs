using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAndSlowDownLine : MonoBehaviour
{
    public float bounceForce = 10f;
    public float acceleration = -5f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
           
            Vector2 bounceDirection = collision.contacts[0].normal;
            rb.velocity = bounceDirection * bounceForce;
            Vector2 currentVelocity = rb.velocity.normalized;
            Vector2 newVelocity = currentVelocity * acceleration + rb.velocity;
            rb.velocity = newVelocity;
        }
    }
}
