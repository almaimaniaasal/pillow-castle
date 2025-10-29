using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject itemIndicator;
    private GameObject player;
    private bool pickedUp;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pickedUp = false;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (!pickedUp)
        {
            if (distance < 100)
            {
                itemIndicator.SetActive(true);
            }
            else
            {
                itemIndicator.SetActive(false);
            }
        }
    }

    public void PickItem()
    {
       transform.SetParent(player.transform);
       transform.localPosition = new Vector3(0,54,0);
       itemIndicator.SetActive(false);
       GetComponent<BoxCollider2D>().isTrigger = true;
       pickedUp = true;
    }
    
}
