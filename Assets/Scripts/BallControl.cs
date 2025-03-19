using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        { 
            rb2d.AddForce(new Vector2(20, -15));
            // doc add force https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html

        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    [SerializeField] private int wallCollisionCount;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "King")
        {
            //Debug.Log("King Punch!");
            rb2d.AddForce(new Vector2(20,-15));
            wallCollisionCount = 0;

        }
        else if (coll.gameObject.name == "Pig")
        {
            rb2d.AddForce(new Vector2(-20,-15));
            wallCollisionCount = 0;
        }
        else //jika terkena wall
        {
            wallCollisionCount = wallCollisionCount + 1;
            Debug.Log("Wall Collision! = " + wallCollisionCount);
            if (wallCollisionCount > 6) GoBall();
        }
    }

}