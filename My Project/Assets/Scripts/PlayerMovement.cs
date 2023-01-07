using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float speed = 5.0f; 
    
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            // Calculate the direction the player should move
            Vector2 direction = (Vector2)(mousePosition - transform.position);

            // Normalize the direction to ensure consistent movement speed
            direction = direction.normalized;

            // Move the player in the specified direction
            transform.position = transform.position + (Vector3) (direction * speed * Time.deltaTime);
        }
    }
}
