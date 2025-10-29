using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Build : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    //[SerializeField] private Sprite completedCastle;
    [SerializeField] private float itemsTotal;
    [SerializeField] private GameObject buildShadow;
    public TextMeshProUGUI scoreText;
    public GameObject whenpanel;
    private GameObject player;
    private int itemCount;

    public int ItemCount {  get { return itemCount; } }
   


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
            scoreText.text = "item:" + itemCount;

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
            
            if (itemCount == itemsTotal)
            {
                //particle.SetActive(false);
                Color spriteColor = buildShadow.GetComponent<SpriteRenderer>().color;
                spriteColor.a = 0;
                buildShadow.GetComponent<SpriteRenderer>().color = spriteColor;

                whenpanel.SetActive(true);
            }
            
        }
    }
}
