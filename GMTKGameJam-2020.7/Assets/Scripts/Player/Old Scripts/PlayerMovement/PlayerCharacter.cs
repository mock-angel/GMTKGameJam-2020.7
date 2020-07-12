using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private PlayerCharacter_Base playerCharacterBase;
    
    private void Awake()
    {
        //ref to base class (allows access to all animations)
        playerCharacterBase = gameObject.GetComponent<PlayerCharacter_Base>();    
    }

    private void Update()
    {
        float speed = 40f;
        float moveX = 0f;
        float moveY = 0f;

        //move up
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        //move down
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        //move left
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY);
        transform.position += moveDir * speed * Time.deltaTime;

    }
}
