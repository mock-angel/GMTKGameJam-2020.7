using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potionstatic : MonoBehaviour
{
    public SpriteRenderer[] Effect;

    public Slider[] CoolDown;

    public float[] CoolDownSeconds;
    public float[] PotUseSeconds;

    public Color Fire, Ice, Air;
    Color[] PotCol = new Color[3];

    public KeyCode[] PotionKeys;

    public float[] Timer = new float[3];


    // Start is called before the first frame update
    void Start()
    {

        PotCol[0] = Fire;
        PotCol[1] = Ice;
        PotCol[2] = Air;

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < CoolDown.Length; i++)
        {
            
            CoolDown[i].value = (CoolDown[i].value < 1? CoolDown[i].value + ((float)1 / (float)60/CoolDownSeconds[i]) : 1);
            if (Input.GetKeyDown(PotionKeys[i]) && CoolDown[i].value >= 1)
            {
                CoolDown[i].value = 0;
                Use(i + 1);
            }

            Timer[i] -= (float)1 / (float)60 / PotUseSeconds[i];
            if (Timer[i] <= 0)
            {
                Effect[i].color = Color.clear;
                Timer[i] = 0;
            }
        }
        
        
        
    }

    public void Check(int ID)
    {
        if (CoolDown[ID - 1].value >= 1)
        {
            CoolDown[ID - 1].value = 0;
            Use(ID);
        }
    }

    public void Use(int ID)
    {

        Effect[ID - 1].color = PotCol[ID - 1];
        Timer[ID - 1] = 1;

    }
}
