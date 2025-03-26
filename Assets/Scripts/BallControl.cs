using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float rand;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }
    private void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        { 
            rb2d.AddForce(new Vector2(20, -15));

        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    public void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    

    public void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    [SerializeField] private int wallCollisionCount;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        // Debug.Log("Ball collided with: " + coll.gameObject.name + " | Velocity: " + rb2d.velocity);
        if (coll.gameObject.CompareTag("Player"))
        {
            float maxSpeed = 15f;
            rb2d.velocity *= 1.05f;

            if (rb2d.velocity.magnitude > maxSpeed)
            {
                rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
            }
        }
            else 
            {
                wallCollisionCount = wallCollisionCount + 1;
                // Debug.Log("Wall Collision! = " + wallCollisionCount);
            }
    }

}