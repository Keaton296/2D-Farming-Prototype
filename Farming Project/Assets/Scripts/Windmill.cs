using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : Building,IInteractable
{
    [SerializeField]Item flour;
    [SerializeField]Item requireditem;
    [SerializeField]float grinding_seconds = 10f;
    [SerializeField]bool isworking = false;
    [SerializeField]bool hasitem = false;
    public void Interact(Tile tile,PlayerInput playerInput)
    {
        
            if (hasitem == false && playerInput.playerStats.helditem == requireditem && !isworking)
            {
                playerInput.playerStats.DeleteItem(playerInput.helditem_spriterenderer);
                StartCoroutine(Grind(grinding_seconds));
            }
            else if (hasitem == true && playerInput.playerStats.helditem == null)
            {
                playerInput.playerStats.AddItem(flour,playerInput.helditem_spriterenderer);
                hasitem = false;
            }
        
    }
    IEnumerator Grind(float process_time)
    {
        Debug.Log("Started Grinding");
        isworking = true;
        yield return new WaitForSeconds(process_time);
        hasitem = true;
        Debug.Log("Grinding Done!");
        isworking = false;

    }
}
