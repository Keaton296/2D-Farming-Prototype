using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile 
{
    public IInteractable tileinteractable;
    public Tile(IInteractable interactable)
    {
        tileinteractable = interactable;
    }
    public Tile()
    {

    }
}
public interface IInteractable
{
    void Interact(Tile _tile,PlayerInput playerInput);
}
