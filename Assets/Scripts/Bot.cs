using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bot : MonoBehaviour
{
    public Transform ball;
    public float speed = 7.0f;
    public float boundY = 3.5f;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var vel = rb2d.velocity;

        if (ball.position.y > transform.position.y + 0.1f)
        {
            vel.y = speed;
        }
        else if (ball.position.y < transform.position.y - 0.1f)
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
