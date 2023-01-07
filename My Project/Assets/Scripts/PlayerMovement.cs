using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float speed = 3.0f; 
    // Set this to the distance threshold at which the player stops
    public float stopDistance = 0.1f;
    public Vector3 mousePosition;
    public Vector3 direction;
    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            direction = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0).normalized;
        }
        
        
        // Check the distance to the target position
        float distance = Vector3.Distance(transform.position, mousePosition);

        AnimateMovement(direction, distance);
        

        // If the distance is greater than the stop distance, move the player
        if (distance > stopDistance)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        // Otherwise, stop the player
        else
        {
            direction = Vector3.zero;
        }
        
        void AnimateMovement(Vector3 direction, float distance)
        {
            // Debug.Log(animator);
            if(animator != null)
            {
                // Debug.Log(distance);
                if(distance > stopDistance)
                {
                    // Debug.Log(distance);
                    animator.SetBool("isMoving", true);
                    animator.SetFloat("Horizontal", direction.x);
                    animator.SetFloat("Vertical", direction.y);
                }
                else
                {
                    animator.SetBool("isMoving", false); 
                }
            }
        }
        
    }
}
 