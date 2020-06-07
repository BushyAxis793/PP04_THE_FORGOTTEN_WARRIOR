using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    Rigidbody2D myRigidbody2D;



    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

    }

    private void Move()
    {
        if (IsLookingRight())
        {

            myRigidbody2D.velocity = new Vector2(walkSpeed, 0f);
        }
        else
        {
            myRigidbody2D.velocity = new Vector2(-walkSpeed, 0f);
        }
    }
    bool IsLookingRight()
    {
        return transform.localScale.x > 0;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody2D.velocity.x)), 1f);
    }
}
