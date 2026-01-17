using UnityEngine;
using UnityEngine.InputSystem;
public class PlaceManager : MonoBehaviour
{   
    public GameObject towerPrefab;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool SpawnTower(Tower.TowerType type, int money)
    {
        if(type == Tower.TowerType.Basic)
        {
            if(money >= towerPrefab.GetComponent<Tower>().price)
            {
                Instantiate(towerPrefab);
                gameManager.money -= towerPrefab.GetComponent<Tower>().price;
                return true;
            }
        }
        if(type == Tower.TowerType.DartGoggins)
        {
            
        }
        if(type == Tower.TowerType.Sniper)
        {
            
        }
        return false;
    }
}
