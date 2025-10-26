using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            moveDirection.y = 0;
        }
        else
        {
            moveDirection.x = 0;       
        }
        
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);
        anim.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (moveDirection != Vector2.zero)
        {
            anim.SetFloat("LastHorizonatal", moveDirection.x);
            anim.SetFloat("LastVertical", moveDirection.y);
        }
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + moveDirection * speed);
    }
}
