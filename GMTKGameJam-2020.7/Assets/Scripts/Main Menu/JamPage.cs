using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamPage : MonoBehaviour
{

    public Transform Main, Page;
    static bool tog;

    static Vector3 Active, Innactive;

    public bool gotojam,leave;

    // Start is called before the first frame update
    void Start()
    {
        Active = Main.localPosition;
        Innactive = Page.localPosition;
    }

    public void Pressed()
    {
        if (leave)
        {
            Application.Quit();
        }


        if (!gotojam)
        {
            tog = !tog;

            Main.localPosition = (!tog ? Active : Innactive);
            Page.localPosition = (tog ? Active : Innactive);
        }
        else
        {
            Application.OpenURL("https://itch.io/jam/gmtk-2020/entries");
        }
        




    }
}
