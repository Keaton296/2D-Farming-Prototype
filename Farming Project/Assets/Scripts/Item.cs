using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Item",menuName="Item")]
public class Item : ScriptableObject
{
    [SerializeField]Sprite _icon;
    [SerializeField]string _name;
    public Sprite icon{get{return _icon;}}
    public new string name{get{return _name;}}
    public virtual void Use(PlayerInput playerInput, Tile tile)
    {
        
    }
}
