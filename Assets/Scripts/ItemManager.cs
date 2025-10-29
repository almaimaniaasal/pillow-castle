using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPlacements;
    [SerializeField] private Sprite[] itemsSprites;

    void Start()
    {
        //randomize item placements (1 item per placement)
        
        List<Sprite> sprites = new List<Sprite>(itemsSprites);

        for (int i = 0; i < sprites.Count; i++)
        {
            int randomIndex = Random.Range(0, sprites.Count);
            Sprite temp = sprites[randomIndex];
            sprites[randomIndex] = sprites[i];
            sprites[i] = temp; 
        }

        for (int i = 0; i < itemPlacements.Length; i++)
        {
            SpriteRenderer spriteRenderer = itemPlacements[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = sprites[i];
            }
        }
    }
}
