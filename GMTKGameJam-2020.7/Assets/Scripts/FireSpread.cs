using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{

    int Timer,Timer2;
    Transform Spread;

    // Start is called before the first frame update
    void Start()
    {
        Spread = transform;
        Spread.position = new Vector3(Random.Range(-0.5f, 0.5f) + Spread.position.x, Random.Range(-0.5f, 0.5f) + Spread.position.y, Spread.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Timer2++;

        if(Timer % 1 == 0)
        {
            if(Random.Range(1,3) == 2)
            {
                Instantiate(gameObject, Spread);




            }


        }






    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            HealthBar.Damage(5);
        }
        Timer = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Timer++;
        if(Timer % 60 == 0)
        {
            HealthBar.Damage(5);
        }
    }
}
