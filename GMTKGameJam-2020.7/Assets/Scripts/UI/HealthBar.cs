using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    static public float HP = 100;

    public Slider Health;
    static Slider HEALTH;

    public Text Parrot;
    static Text PARROT;

    public AudioSource Hurt;
    static AudioSource HURT;

    // Start is called before the first frame update
    void Start()
    {
        HEALTH = Health;
        PARROT = Parrot;
        HURT = Hurt;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void Damage(float D)
    {
        HEALTH.value -= D *0.01f;
        HP = HEALTH.value;
        HURT.Play();
        PARROT.text = Mathf.Round(HEALTH.value * 100) + "";


    }
}
