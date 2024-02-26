using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallProperty : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Colors")]
    public Color Orange;
    public Color Blue;
    public Color Red;
    public SpriteRenderer spriteRenderer;

    [Header("BounceParameters")]
    public float bounceForce = 10;
    public float acceleration = 5;

    public enum Property
    {
        //bounce,
        //speedBounce,
        dangerBounce
    }

    public Property CurrentProperty { get; private set; }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* if(CurrentProperty == Property.bounce)
         {
             spriteRenderer.color = Orange;
         }

         else if(CurrentProperty == Property.speedBounce)
         {
             spriteRenderer.color = Blue;
         }

         else */
      /*  if (CurrentProperty == Property.dangerBounce)
        {
            spriteRenderer.color = Red;
        }*/
    }

    public void SetProperty(Property newProperty)
    {
        CurrentProperty = newProperty;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*if (CurrentProperty == Property.bounce)
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {

                    Vector2 incomingVector = rb.velocity;
                    Vector2 bounceDirection = collision.contacts[0].normal;
                    Vector2 reflectVector = Vector2.Reflect(incomingVector, bounceDirection);
                    rb.velocity = reflectVector.normalized * bounceForce;
                }
            }

            else if (CurrentProperty == Property.speedBounce)
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

                Vector2 incomingVector = rb.velocity;
                Vector2 bounceDirection = collision.contacts[0].normal;
                Vector2 reflectVector = Vector2.Reflect(incomingVector, bounceDirection);

                rb.velocity = reflectVector.normalized * bounceForce;
                Vector2 currentVelocity = rb.velocity.normalized;
                Vector2 newVelocity = currentVelocity * acceleration + rb.velocity;
                rb.velocity = newVelocity;
            }*/

            /*   if (CurrentProperty == Property.dangerBounce)
                {
                    Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 incomingVector = rb.velocity;
                        Vector2 bounceDirection = collision.contacts[0].normal;
                        Vector2 reflectVector = Vector2.Reflect(incomingVector, bounceDirection);
                        rb.velocity = reflectVector.normalized * bounceForce;
                        gameManager.ChangeHealth(-1);
                    }
                }*/

            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 incomingVector = rb.velocity;
                Vector2 bounceDirection = collision.contacts[0].normal;
                Vector2 reflectVector = Vector2.Reflect(incomingVector, bounceDirection);
                rb.velocity = reflectVector.normalized * bounceForce;
            }
        }
    }
}



