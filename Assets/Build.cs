using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private Sprite completedCastle;
    
    private bool isBuilt;
    private bool firstItem;
    private int itemCount;
    
    private void Start()
    {
        isBuilt = false;
        firstItem = false;
        itemCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (firstItem == true)
        {
            //start building
            //play particle
            //Increase item count
            //check if item count is 20
            //then stop the particle
            //show the completed pillow castle
            
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            firstItem = true;
            //destroy item
            
        }
    }
}
