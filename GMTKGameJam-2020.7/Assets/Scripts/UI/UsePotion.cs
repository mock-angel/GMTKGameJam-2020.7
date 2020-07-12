using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsePotion : MonoBehaviour
{

    public int ID;
    public potionstatic P;

    public void Clicked()
    {
        P.Check(ID);

    }

}
