using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    //[Range(0, 100)]
    //private float health;

    [SerializeField]
    [Range(0, 100)]
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

    public GameObject secondaryObjectToMove;

    public bool dead = false;

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
        if(dead) return;

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
        
        //if player is dead
        if (HealthBar.HP <= 0) 
        {
            rb.velocity = new Vector2(0, 0);
            rb.MovePosition(transform.position);

            transform.position = transform.position;

            //Death Animation
            animator.SetBool("IsDead", true);

            //gameObject.GetComponent<SpriteRenderer>().enabled = false;

            GameManager.GameIsPaused = true;
            dead = true;
        }

    }
    
    void FixedUpdate()
    {   
        //transform.position = transform.position + (movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + ((new Vector2(movement.x, movement.y)) * moveSpeed * Time.fixedDeltaTime));
        secondaryObjectToMove.transform.position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Enemy")
        {
            PlayerMovement.Instance.OnCircleCollision(collision);
        }
    }

    public void OnCircleCollision(Collision2D collision){
        Debug.Log("Player takes damage");

        //Destroy Enemy Object
        GameObject.Destroy(collision.gameObject);

        //Player Takes Damage
        HealthBar.Damage(golemDamage);


        //Health points -=10
        //HealthBar.HP -= golemDamage;

        //play sound
        AudioManager.AudioManagerProp.PlaySFX(TakeDamgeSFX);
    }
    
    public void OnDamageTaken(int damageFromBullet){
        //Player Takes Damage
        HealthBar.Damage(damageFromBullet);

        //Health points -=10
        //HealthBar.HP -= damageFromBullet;

        //play sound
        
        AudioManager.AudioManagerProp.PlaySFX(TakeDamgeSFX);
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        potionstatic.Instance.OnTriggeredFireCircle(collision);
    }
    */
}
