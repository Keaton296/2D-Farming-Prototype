using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats 
{
    public int coins = 3;
    public Item helditem;
    public PlayerStats()
    {
        
    }
    public PlayerStats(int coin_amount, Item holdingitem)
    {
        helditem = holdingitem;
        coins = coin_amount;
        
    }
    public void AddItem(Item item,SpriteRenderer renderer)
    {
        helditem = item;
        renderer.sprite = item.icon;
    }
    public void DeleteItem(SpriteRenderer renderer)
    {
        renderer.sprite = null;
        helditem = null;
    }
}
