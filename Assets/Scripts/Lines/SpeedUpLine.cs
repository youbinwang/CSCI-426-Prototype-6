using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpLine : MonoBehaviour
{
    public float acceleration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 currentVelocity = rb.velocity.normalized;
                Vector2 newVelocity = currentVelocity * acceleration + rb.velocity;
                rb.velocity = newVelocity;
            }
        }
    }
}
