using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    public int damage;
    public int reach;
    public int bulletSpeed;
    public float reload;
    public int price;
    public List<Enemy> oppReach;
    private CircleCollider2D col;
    public GameObject projectilePrefab;
    public GameObject RangeSprite;
    public enum TowerType
    {
        DartGoggins, Basic, Sniper, CircleShooter
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        col = GetComponent<CircleCollider2D>();
        col.radius = reach;
        RangeSprite.transform.localScale = new Vector3(reach*2,reach*2,1);
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
    public void Shoot(Vector3 target)
    {
        if (GetComponent<Placeable>().isPlaced)
        {
            
        
            // Calculate direction to shoot toward
            Vector3 origin = transform.position;
            Vector3 direction = (target - origin).normalized; // This makes it just the direction and not affected by how far it is

            // Generate new Projectile
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = origin; // Set initial position of projectile at Tower

            // Add force to projectile's rigidbody
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse); // We use the bulletSpeed variable here
            Destroy(projectile, Time.deltaTime*(reach/bulletSpeed));
        }
    }
    public IEnumerator ShootAtEnemy()
    {
        while (true)
        {
            if(oppReach.Count > 0) // If there are enemies in reach
            {
                Debug.Log(oppReach);
                ShootActions();
            }
            yield return new WaitForSeconds(reload); // Wait to try again for the "reload" time
        }
    }
    public virtual void ShootActions()
    {
        
    }

}
