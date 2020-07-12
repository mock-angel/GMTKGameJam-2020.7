using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    Text T;
    static public bool START = true;
    static public bool DONE;

    int tiem;
    bool hasbeenS;

    // Start is called before the first frame update
    void Start()
    {
        T = GetComponent<Text>();
        T.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (START)
        {
            hasbeenS = true;
            tiem++;
            int temp = 180 - (tiem / 60);
            T.text = temp + " seconds remain";
            if(temp == 0)
            {
                DONE = true;
                temp = 0;
                //pause game
            }
        }

        if (GameManager.GameIsPaused == true)
        {
            START = false;
        }
        else
        {
            if (hasbeenS)
            {
                START = true;
            }
            
        }



    }



    public static void begin()
    {

        START = true;

    }
}
