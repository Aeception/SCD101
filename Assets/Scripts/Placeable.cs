using UnityEngine;
using UnityEngine.InputSystem;
public class Placeable : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool isPlaced = false;
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (!isPlaced) // Keep following mouse if not placed yet
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 10f)); 

            worldPos.z = 0f; 
            transform.position = worldPos;

            if (Mouse.current.leftButton.wasPressedThisFrame) // Once we left-click though...
            {
                isPlaced = true;
            }
            
        }
    }

    
}
