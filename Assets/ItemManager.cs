using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPlacements;
    [SerializeField] private Sprite[] itemsSprites;

    void Start()
    {
        //randomize item placements
        foreach (GameObject item in itemPlacements)
        {
            SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && itemsSprites.Length > 0)
            {
                spriteRenderer.sprite = itemsSprites[Random.Range(0, itemsSprites.Length)];
            }
        }
    }
}
