using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    

    static public float HP = 100;

    public Slider Health;
    static Slider HEALTH;


    // Start is called before the first frame update
    void Start()
    {
        HEALTH = Health;   



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void Damage(float D)
    {
        HEALTH.value -= D *0.01f;

        


    }
}
