using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int popcount;
    public int originalPopcount;
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
        ColorChange();
        originalPopcount = popcount;
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
        if(collision.GetComponent<Projectile>() != null)
        {
            int damage = collision.GetComponent<Projectile>().damage;
            popcount -= damage;
            ColorChange();
            Destroy(collision.gameObject);
            if(popcount <= 0)
            {
                Ondeath();
                
            }
        }
    }
    void Ondeath()
    {
        Vector3 deathPos = this.transform.position;
        Destroy(this.gameObject);
        GameObject newEnemyPrefab = null;
        if(enemyType == EnemyType.Square)
        {
            newEnemyPrefab = spawnManager.circlePrefab;
        }
        else if(enemyType == EnemyType.Triangle)
        {
            newEnemyPrefab = spawnManager.squarePrefab;
        }

        if(newEnemyPrefab != null)
        {
            StartCoroutine(SpawnMORE(newEnemyPrefab, deathPos));
        }

    }
    IEnumerator SpawnMORE(GameObject prefab, Vector3 deathPos)
    {
        for(int i = 1; i <= 2; i++)
        {
            GameObject newEnemy = Instantiate(prefab); // newEnemyPrefab is set to non-null if this enemy is a Square or a Triangle
            newEnemy.transform.position = deathPos;
            newEnemy.GetComponent<Enemy>().direction = direction;
            newEnemy.GetComponent<Enemy>().popcount = originalPopcount;
            newEnemy.GetComponent<Enemy>().ColorChange();
            yield return new WaitForSeconds(1f);
        }
    }
    void ColorChange()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        List<Color> healthColors = new List<Color>{Color.red, Color.blue, Color.green};

	// we subtract 1 because a popcount of 1 means it's red, so it needs the 0th index!
        int colorIndex = Math.Max(0, Math.Min(popcount-1, 2)); // keep number between 0 and 2 for now since I only have 3 colors
        sr.color = healthColors[colorIndex]; 
    }

    
}
