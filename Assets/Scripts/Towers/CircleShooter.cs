using UnityEngine;

public class CircleShooter : Tower
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shoot8()
    {
        Shoot(new Vector3(transform.position.x, transform.position.y+1));
        Shoot(new Vector3(transform.position.x+1, transform.position.y+1));
        Shoot(new Vector3(transform.position.x+1, transform.position.y));
        Shoot(new Vector3(transform.position.x+1, transform.position.y-1));
        Shoot(new Vector3(transform.position.x, transform.position.y-1));
        Shoot(new Vector3(transform.position.x-1, transform.position.y-1));
        Shoot(new Vector3(transform.position.x-1, transform.position.y));
        Shoot(new Vector3(transform.position.x-1, transform.position.y+1));
    }
    public override void ShootActions()
    {
        base.ShootActions();
        Shoot8();
    }
}
