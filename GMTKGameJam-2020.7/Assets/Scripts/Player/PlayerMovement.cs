using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance {get; private set;}
    public float moveSpeed = 5f;
    
    //public Rigidbody2D rb;
    public Animator animator;
    
    Vector3 movement;
    Vector3 axis;
    
    void Start(){
        Instance = this;
    }

    void Awake(){
        Instance = this;
    }

    void Update()
    {
        movement.x = axis.x = Input.GetAxisRaw("Horizontal");
        movement.y = axis.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);



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
        transform.position = transform.position + (movement * moveSpeed * Time.fixedDeltaTime);
//        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
