using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFire : MonoBehaviour
{
    public float Radius;
    int Timer;

    [SerializeField]
    Vector2 Offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer++;

        transform.localPosition = new Vector3(Radius*Mathf.Cos(Timer) + Offset.x,Radius*Mathf.Sin(Timer) + Offset.y,0);

    }
}
