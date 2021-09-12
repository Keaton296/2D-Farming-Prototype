using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour,IInteractable
{
    SpriteRenderer spriteRenderer;
    public Item droppeditem;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Interact(Tile tile,PlayerInput playerInput)
    {
        if (playerInput.playerStats.helditem == null)
        {
            playerInput.playerStats.AddItem(droppeditem,playerInput.helditem_spriterenderer);
            tile.tileinteractable = null;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Your hands are full.");
        }
    }
}
