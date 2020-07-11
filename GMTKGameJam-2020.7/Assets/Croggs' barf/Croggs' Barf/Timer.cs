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
            tiem++;
            int temp = 180 - (tiem / 60);
            T.text = temp + " seconds remain";
            if(temp == 0)
            {
                DONE = true;
            }
        }




    }



    public static void begin()
    {

        START = true;

    }
}
