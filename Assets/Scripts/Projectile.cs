using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : MonoBehaviour
{
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitTilDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitTilDestroy()
    {
        yield return new WaitForSeconds(10f); 
        Destroy(this.gameObject);
    }
}
