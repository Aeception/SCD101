using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int popcount;
    public int speed;
    public int damage;
    public Direction direction;
    private Rigidbody2D rb;
    public enum Direction
    {
        Left, Right, Up, Down
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (direction == Direction.Left)
        {
            rb.linearVelocity = new Vector2(-1, 0) * speed;
        }

        if (direction == Direction.Right)
        {
            rb.linearVelocity = new Vector2(1, 0) * speed;
        }

        if (direction == Direction.Up)
        {
            rb.linearVelocity = new Vector2(0, 1) * speed;
        }

        if (direction == Direction.Down)
        {
            rb.linearVelocity = new Vector2(0, -1) * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ChangeDirection>() != null)
        {
            direction = collision.GetComponent<ChangeDirection>().newDirection;
        }
    }
}
