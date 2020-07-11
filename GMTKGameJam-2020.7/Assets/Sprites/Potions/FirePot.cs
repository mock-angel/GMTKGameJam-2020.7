using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePot : MonoBehaviour
{
    public potionstatic stat;
    public Sprite[] Frames;

    int Timer;
    public float Fps;

    SpriteRenderer S,B;
    int FrameTracker;

    // Start is called before the first frame update
    void Start()
    {
        S = GetComponent<SpriteRenderer>();
        B = transform.Find("Base").GetComponent<SpriteRenderer>();
        S.sprite = Frames[0];
    }

    // Update is called once per frame
    void Update()
    {
        Timer++;

        if(Timer % (60f/Fps) == 0)
        {
            FrameTracker++;
            if(FrameTracker >= Frames.Length)
            {
                FrameTracker = 0;
            }
            S.sprite = Frames[FrameTracker];

        }

        B.color = new Color(stat.Timer[0], 0, 0,stat.Timer[0]/2);


    }
}
