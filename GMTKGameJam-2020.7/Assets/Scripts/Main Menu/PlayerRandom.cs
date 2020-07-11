using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandom : MonoBehaviour
{

    public int Timer;

    Animator Anim;
    Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();


        Anim.SetFloat("Vertical", 0);
        Anim.SetFloat("Horizontal", 0);
        Anim.SetFloat("Speed", 0);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Timer % 60 == 0)
        {

            if(Random.RandomRange(1,3) == 2)
            {
                float V = Random.RandomRange(-1.5f, 1.5f);
                float H = Random.RandomRange(-1.5f, 1.5f);



                Anim.SetFloat("Vertical", V);
                Anim.SetFloat("Horizontal", H);
                Anim.SetFloat("Speed", Mathf.Sqrt((V*V) + (H*H)));
                Rb.velocity = new Vector2(H, V);

            }


        }
        Timer++;

        if(transform.position.y > 6f)
        {
            transform.position = new Vector3(transform.position.x, -5.5f,0);
        }

        if(transform.position.y < -6f)
        {
            transform.position = new Vector3(transform.position.x, 5.5f, 0);
        }

        if (transform.position.x < -10f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }

        if (transform.position.x > 10)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }




    }
}
