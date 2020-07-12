using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float health;

    [SerializeField]
    private float golemDamage;

    [SerializeField]
    private AudioClip TakeDamgeSFX;

    [SerializeField]
    private AudioClip WalkSFX;

    public bool Walking;

    public static PlayerMovement Instance {get; private set;}
    public float moveSpeed = 5f;

    
    //public Rigidbody2D rb;
    public Animator animator;

    AudioSource audiosource;

    Vector3 movement;
    Vector3 axis;

    Rigidbody2D rb;


    void Start(){
        Instance = this;
        gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();


    }

    void Awake(){
        Instance = this;
    }

    void Update()
    {
        movement.x = axis.x = Input.GetAxisRaw("Horizontal");
        movement.y = axis.y = Input.GetAxisRaw("Vertical");
        
     
        audiosource.mute = !(Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0);
        


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
        //transform.position = transform.position + (movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + ((new Vector2(movement.x, movement.y)) * moveSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Enemy" && GetComponent<CircleCollider2D>().isTrigger)
        {
            Debug.Log("Player takes damage");

            //Destroy Enemy Object
            GameObject.Destroy(collision.gameObject);

            //Player Takes Damage
            HealthBar.Damage(golemDamage);


            //Health points -=10
            HealthBar.HP -= golemDamage;

            //play sound
            AudioManager.AudioManagerProp.PlaySFX(TakeDamgeSFX);


            health -= golemDamage;

            
            //if player is dead
            if (HealthBar.HP < 0 && health < 0) 
            {
                //Death Animation
                animator.SetBool("IsDead", true);

                gameObject.GetComponent<SpriteRenderer>().enabled = false;

                GameManager.GameIsPaused = true;

            }

        }

        
    }


}
