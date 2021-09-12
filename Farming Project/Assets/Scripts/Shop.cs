using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Building,IInteractable
{
    [SerializeField]Item whatbuys;
    [SerializeField]int sellsitemfor;
    [SerializeField]int buysitemfor;
    [SerializeField]Item whatsells;
    public void Interact(Tile tile,PlayerInput playerInput)
    {
        if (playerInput.playerStats.helditem == null && playerInput.playerStats.coins >= sellsitemfor)
        {
            playerInput.playerStats.coins--;
            Debug.Log(whatsells.name + " bought for " + sellsitemfor.ToString() +" gold.");
            playerInput.playerStats.AddItem(whatsells,playerInput.helditem_spriterenderer);
        }
        else if (playerInput.playerStats.helditem == whatbuys)
        {
            Debug.Log(  playerInput.playerStats.helditem.name +" sold for " + buysitemfor.ToString() + " gold.");
            playerInput.playerStats.coins += buysitemfor;
            playerInput.playerStats.DeleteItem(playerInput.helditem_spriterenderer);
        }   
    }
}
