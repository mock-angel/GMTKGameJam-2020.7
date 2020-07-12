using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePot : MonoBehaviour
{

    public Sprite[] Frames;

    int Timer,Timer2;
    public float Fps;

    SpriteRenderer S;
    int FrameTracker;

    public bool IsOnFire;
    public float BurnFrames;

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

        if(Timer % (60f/Fps) == 0)
        {
            FrameTracker++;
            if(FrameTracker >= Frames.Length)
            {
                FrameTracker = 0;
            }
            S.sprite = Frames[FrameTracker];

        }
        
        if (IsOnFire && S.color == Color.white)
        {
            
            Timer2++;
            if(Timer2 > BurnFrames)
            {
                GameObject.Destroy(transform.parent.gameObject);
            }
            transform.parent.GetComponent<SpriteRenderer>().color -= new Color(1f/BurnFrames, 1f / BurnFrames, 1f / BurnFrames, 0);

        }

    }

}
