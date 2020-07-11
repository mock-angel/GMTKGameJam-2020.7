using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    
    public Animator animator;
    
    Vector3 movement;
    Vector3 axis;
    
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
        
    }
    
    void FixedUpdate()
    {   
        transform.position = transform.position + (movement * moveSpeed * Time.fixedDeltaTime);
    }
}