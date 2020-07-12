using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{

    int Timer,Timer2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer2++;

        if(Timer2 % 600 == 0)
        {
            if(Random.Range(1,5) == 2)
            {



                //Instantiate(transform.Find("Next").transform , transform.parent);
                Instantiate(gameObject, transform.Find("Next").transform.position, new Quaternion(0, 0, 0, 1), transform.parent);
                

            }


        }






    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Physics2D.Distance(collision,GetComponent<Collider2D>()).distance < 3)
        {
            HealthBar.Damage(5);
        }
        Timer = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Timer++;
        if(Timer % 60 == 0 && collision.tag == "Player" && Physics2D.Distance(collision, GetComponent<Collider2D>()).distance < 3)
        {
            HealthBar.Damage(5);
        }
    }
}
