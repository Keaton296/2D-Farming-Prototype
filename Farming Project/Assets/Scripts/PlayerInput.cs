using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    [SerializeField] CustomTilemap map; //this should be in a singleton pattern
    [SerializeField] PlayerMovement playerMovement;
    public PlayerStats playerStats;
    public SpriteRenderer helditem_spriterenderer;
    [SerializeField] KeyCode use_key = KeyCode.E;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        helditem_spriterenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        playerStats = new PlayerStats(3,null);
        
    }

    
    void Update()
    {
        playerMovement.Move();
        if (Input.GetKeyDown(use_key)) map.InteractWithTile(this,transform.position);
        map.DrawBoxAt(transform.position);
        
    }
    
    
}
