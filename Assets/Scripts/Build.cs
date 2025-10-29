using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private Sprite completedCastle;
    
    private GameObject player;
    private int itemCount;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itemCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Item"))
        {
            
            //destroy item
            collision.gameObject.SetActive(false);
            player.gameObject.GetComponent<PlayerMovement>().IsPicked = false;
            //Increase item count
            itemCount++;
            //check if item count is 20
            Debug.Log(itemCount);
            
        }
    }

    private void Update()
    {
        if (itemCount > 0)
        {
            //start particle system
            particle.SetActive(true);
            
            if (itemCount == 20)
            {
                particle.SetActive(false);
                GetComponent<SpriteRenderer>().sprite = completedCastle;
                
            }
            
        }
    }
}
