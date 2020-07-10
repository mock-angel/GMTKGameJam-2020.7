using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;
    
    Vector3 movement;
    Vector3 axis;
    
    void Update()
    {
        movement.x = axis.x = Input.GetAxisRaw("Horizontal");
        movement.y = axis.y = Input.GetAxisRaw("Vertical");
        
        if (Mathf.Abs(axis.x) == 1 && Mathf.Abs(axis.y) == 1)
        {
            movement.x = Mathf.Sqrt(0.5f) * axis.x;
            movement.y = Mathf.Sqrt(0.5f) * axis.y;
        }
        
        //Fixed update script
        
//        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
//        Vector2 addForce = new Vector2(movement.x * moveSpeed * Time.deltaTime, movement.y * moveSpeed * Time.deltaTime);
//        rb.AddForce(addForce);
    }
    
    void FixedUpdate()
    {   
        transform.position = transform.position + (movement * moveSpeed * Time.deltaTime);
//        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
