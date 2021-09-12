using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour,IInteractable
{
    [SerializeField]Seed cropseed;
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField] bool isgrown = false;

    

    void Start()
    {
        
    }
    public void StartGrowing(Seed seed)
    {
        cropseed = seed;
        StartCoroutine("Grow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Grow()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        float sprite_interval_second = cropseed.growth_time / cropseed.growth_sprites.Length;
        for (int i = 0; i < cropseed.growth_sprites.Length; i++)
        {
            spriteRenderer.sprite = cropseed.growth_sprites[i];
            if(i == cropseed.growth_sprites.Length-1)
            {
                isgrown = true;
                break;
            } 
            yield return new WaitForSeconds(sprite_interval_second);
        }
    }
    public void Interact(Tile tile,PlayerInput playerInput)
    {
        if (isgrown && playerInput.playerStats.helditem == null)
        {
        playerInput.playerStats.helditem = cropseed.groweditem;
        playerInput.helditem_spriterenderer.sprite = playerInput.playerStats.helditem.icon;
        Debug.Log("Picked up " + cropseed.groweditem.ToString());
        tile.tileinteractable = null;
        Destroy(gameObject);
        }
        else if(!isgrown && playerInput.playerStats.helditem == null)
        {
            playerInput.playerStats.helditem = cropseed;
            playerInput.helditem_spriterenderer.sprite = playerInput.playerStats.helditem.icon; 
            Debug.Log("Picked up " + cropseed.ToString());           
            tile.tileinteractable = null;
            Destroy(gameObject);
        }
    }
}
