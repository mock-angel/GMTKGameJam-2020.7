using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPot : MonoBehaviour
{
    public potionstatic stat;
    public Sprite[] Frames;

    int Timer, Timer2;
    public float Fps;

    SpriteRenderer S;
    int FrameTracker;

    // Start is called before the first frame update
    void Start()
    {
        S = GetComponent<SpriteRenderer>();
        S.sprite = Frames[0];
    }

    // Update is called once per frame
    void Update()
    {
        Timer++;

        if (Timer % (60f / Fps) == 0)
        {
            FrameTracker++;
            if (FrameTracker >= Frames.Length)
            {
                FrameTracker = 0;
            }
            S.sprite = Frames[FrameTracker];

        }

        if(stat.CoolDown[2].value > 0.95f)
        {
            S.transform.parent.GetComponent<PlayerMovement>().moveSpeed = 5;
        }
        else
        {
            S.transform.parent.GetComponent<PlayerMovement>().moveSpeed = 5 + ((stat.CoolDown[2].value * stat.CoolDown[2].value)*300);
        }

        

    }
}
