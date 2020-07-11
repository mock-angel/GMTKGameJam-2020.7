using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public RectTransform Health;
    public static RectTransform HEALTH;

    static public float HP = 100;

    static float w, fullx, emptyx;


    // Start is called before the first frame update
    void Start()
    {
        HEALTH = Health;
        w = Health.sizeDelta.x;

        fullx = Health.localPosition.x;
        emptyx = Health.localPosition.x - w;



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void Damage(float D)
    {
        HP =- D;

        HEALTH.localPosition -= new Vector3(w * (100 / D),0,0);


    }
}
