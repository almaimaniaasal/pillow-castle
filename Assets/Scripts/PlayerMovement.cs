using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator anim;
    private RaycastHit2D hit;
    private Vector2 lastDirection;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        layerMask = LayerMask.GetMask("Items");
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveDirection != Vector2.zero)
        {
            lastDirection = moveDirection.normalized;
        }
        
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
        
        Vector2 rayOrigin = (Vector2)transform.position + lastDirection * 50f;
        
        hit = Physics2D.Raycast(rayOrigin, lastDirection, 100, layerMask);
        Debug.DrawRay(rayOrigin, lastDirection * 100, Color.red);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            PickUp pickUp = hit.collider.gameObject.GetComponent<PickUp>();
            if (pickUp != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickUp.PickItem();
                }
            }
        }
    }
}
