using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int hp;
    public int money;
    public PlaceManager placeManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    public void BuyBasicTower()
    {
        placeManager.SpawnTower(Tower.TowerType.Basic, money);
    }
    public void BuyCircleShooterTower()
    {
        placeManager.SpawnTower(Tower.TowerType.CircleShooter, money);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null) // If the thing that collided with the GameManager is an Enemy...
        {
            hp -= collision.GetComponent<Enemy>().popcount; // Reduce HP by its popcount
            Destroy(collision.gameObject); // Then destroy it.
        }
    }
}
