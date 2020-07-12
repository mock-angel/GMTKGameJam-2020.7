using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvHazard : MonoBehaviour
{
    [SerializeField]
    bool IsCob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (IsCob)
            {
                collision.GetComponent<PlayerMovement>().moveSpeed = 1;
            }
            else
            {
                HealthBar.Damage(2);
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (IsCob)
            {
                collision.GetComponent<PlayerMovement>().moveSpeed = 1;
                print("SLOW");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().moveSpeed = 5;
        }
    }
}
