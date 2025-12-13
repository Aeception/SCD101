using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    public int damage;
    public int reach;
    public int bulletSpeed;
    public int reload;
    public List<Enemy> oppReach;
    private CircleCollider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        col.radius = reach;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemyScript = collision.GetComponent<Enemy>();
        oppReach.Add(enemyScript);
    }
        void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemyScript = collision.GetComponent<Enemy>();
        oppReach.Remove(enemyScript);
    }
}
