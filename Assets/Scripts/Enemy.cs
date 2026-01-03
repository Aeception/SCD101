using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int popcount;
    public int speed;
    public int damage;
    public EnemyType enemyType;
    public enum EnemyType
    {
        Circle, Square, Triangle
    }
    public Direction direction;
    private Rigidbody2D rb;
    private SpawnManager spawnManager;
    public enum Direction
    {
        Left, Right, Up, Down
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
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
    void OnDeath()
    {
        Destroy(this.gameObject);
        if(enemyType == EnemyType.Circle)
        {
            for(int i = 1; i <= 2; i++)
            {
                GameObject newEnemy = Instantiate(spawnManager.circlePrefab);
                newEnemy.transform.position = this.transform.position;
                newEnemy.GetComponent<Enemy>().direction = direction;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ChangeDirection>() != null)
        {
            direction = collision.GetComponent<ChangeDirection>().newDirection;
        }
        if(collision.GetComponent<Projectile>() != null)
        {
            int damage = collision.GetComponent<Projectile>().damage;
            popcount -= damage;
            Destroy(collision.gameObject);
            if(popcount <= 0)
            {
                OnDeath();
                
            }
        }
    }
}
