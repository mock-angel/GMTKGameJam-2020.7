using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePot : MonoBehaviour
{
    public potionstatic stat;
    public Sprite[] Frames;

    int Timer;
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
        if(stat.Timer[1] > 0.95f)
        {
            FrameTracker = 0;
        }

        if (Timer % (60f / Fps) == 0)
        {
            FrameTracker++;
            if (FrameTracker < Frames.Length)
            {
                S.sprite = Frames[FrameTracker];
            }
            

        }


        S.color = new Color(1, 1, 1, stat.Timer[1]);


    }
}
