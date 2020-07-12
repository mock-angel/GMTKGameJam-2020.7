using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotSelect : MonoBehaviour
{


    public Image[] Highlights;
    public SpriteRenderer Halo;
    Transform[] Trans;

    public bool DoHighlight;
    float Timer;


    // Start is called before the first frame update
    void Start()
    {
        Trans = new Transform[Highlights.Length];
        for (int i = 0; i < Highlights.Length; i++)
        {
            Trans[i] = Highlights[i].GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (DoHighlight)
        {
            Timer += 0.08f;



            float temp = 0.5f * Mathf.Cos(Timer) + 0.5f;
            for (int i = 0;i < Highlights.Length; i++)
            {

                if(Mathf.Round(temp*10)/10f == 0.5f)
                {
                    for (int j = 0; j < Highlights.Length; j++)
                    {
                        Highlights[j].color = new Color(1, 1, 1, 100f / 255f);
                    }
                        
                    DoHighlight = false;
                    Timer = 0;
                    break;
                }
                else
                {
                    Highlights[i].color = new Color(1, 1, 1, temp);
                }

                

                Trans[i].localScale = new Vector3(temp + 0.44f, temp + 0.44f, 0);
            }

            temp = temp * 2 - 1;
            if (Halo != null)
            {
                Halo.color = new Color(1, 1, 1, temp);
            }
            



        }




    }

}
