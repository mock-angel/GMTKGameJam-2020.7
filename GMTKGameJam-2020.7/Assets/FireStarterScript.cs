using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarterScript : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        potionstatic.Instance.OnTriggeredFireCircle(collision);
    }
}
