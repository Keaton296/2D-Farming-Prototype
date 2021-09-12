using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Item",menuName="Seed")]
public class Seed : Item
{
    [SerializeField]float growth_time_seconds = 60f;
    [SerializeField]static GameObject crop_gameobject;
    [SerializeField] Item _groweditem;
    public Sprite[] growth_sprites;
    public float growth_time{get{return growth_time_seconds;}}
    //public Sprite[] growth_sprites {get{return growth_sprites;}}
    public Item groweditem{get{return _groweditem;}} 
    public override void Use(PlayerInput playerInput,Tile tile)
    {
        
    }
}
