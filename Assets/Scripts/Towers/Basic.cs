using UnityEngine;

public class Basic : Tower
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShootAtEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ShootActions()
    {
        base.ShootActions();
        Shoot(oppReach[0].transform.position); // Shoot towards the first enemy in the list
    }
}
