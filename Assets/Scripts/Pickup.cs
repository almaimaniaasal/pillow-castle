using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private RaycastHit2D hit;

    // Update is called once per frame
    void FixedUpdate()
    {
       hit = Physics2D.Raycast(transform.position, Vector2.up);
       Debug.DrawLine(transform.localPosition, Vector2.right * hit.distance, Color.red);
       if (hit.collider.gameObject.tag == "Collectable")
       {
           Debug.Log(hit.collider.gameObject.name);
           
       }
    }
}
