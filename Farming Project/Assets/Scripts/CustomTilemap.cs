using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTilemap : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] FarmObjects farmObjects;
    [SerializeField] int map_x = 16;
    [SerializeField] int map_y = 16;
    Tile[,] tiles;
    [SerializeField] Crop corp;
    [SerializeField] Windmill windlim;
    [SerializeField] Shop shop;
    [SerializeField]Transform player;
    [SerializeField] Color boxcolor;
    [SerializeField] Color mapbordercolor;
    void Start()
    {
        InstantiateTiles();
        grid = GetComponent<Grid>();
    }
    void Update()
    {
        DrawBoxAt(player.position);
        DrawMapBorders();
    }
    public Tile FindTileFromWorldPosition(Vector3 worldPos)
    {
        Vector3Int cellpos = grid.WorldToCell(worldPos);
        if (cellpos.x < 0  || cellpos.y < 0)
        {
            return null;
        }
        return tiles[cellpos.x,cellpos.y];
    }
    void InstantiateTiles()
    {
        tiles = new Tile[map_x,map_y];
        for (int y = 0; y < map_y; y++)
        {
            for (int x = 0; x < map_x; x++)
            {
                tiles[x,y] = new Tile();
            }
        }
        tiles[0,0].tileinteractable = corp;
        tiles[1,0].tileinteractable = windlim;
        tiles[1,1].tileinteractable = shop;
    }
    public void DrawBoxAt(Vector3 pos)
    {
        Vector3 cellposition = transform.position + grid.WorldToCell(pos);
        Debug.DrawLine(cellposition,cellposition + Vector3.up,boxcolor);
        Debug.DrawLine(cellposition,cellposition + Vector3.right,boxcolor);
        Debug.DrawLine(cellposition + Vector3.up,cellposition + Vector3.up + Vector3.right,boxcolor);
        Debug.DrawLine(cellposition+Vector3.right,cellposition + Vector3.up+Vector3.right,boxcolor);
    }
    void ConnectTileWithInteractable(Tile _tile, IInteractable _interactable)
    {
        _tile.tileinteractable = _interactable;
    }
    void DrawMapBorders()
    {
        Vector3 v1 = transform.position + new Vector3(0,map_y,0);
        Vector3 v2 = v1 + new Vector3(map_x,0,0);
        Vector3 v3 = transform.position + new Vector3(map_x,0,0);
        Debug.DrawLine(transform.position, v1,mapbordercolor);
        Debug.DrawLine(v1,v2,mapbordercolor);
        Debug.DrawLine(v2,v3,mapbordercolor);
        Debug.DrawLine(transform.position,v3,mapbordercolor);
    }
    public void PlantCrop(Seed seed,Vector3 playerpos)
    {
        Vector3Int cellpoint = grid.WorldToCell(playerpos);
        Vector3 worldcellmidpoint = transform.position+cellpoint + new Vector3(0.5f,0.5f,0);
        Crop crop = Instantiate(farmObjects.crop,worldcellmidpoint,Quaternion.identity).GetComponent<Crop>();
        crop.StartGrowing(seed);
        tiles[cellpoint.x,cellpoint.y].tileinteractable = crop;
    }
    public void InteractWithTile(PlayerInput playerInput,Vector3 worldPos)
    {
        Tile selectedtile = FindTileFromWorldPosition(worldPos);
        if (selectedtile != null)
        {
            if (selectedtile.tileinteractable != null)
            {
                selectedtile.tileinteractable.Interact(selectedtile,playerInput);
            }
            else if (selectedtile.tileinteractable == null && playerInput.playerStats.helditem is Seed)
            {
                PlantCrop((Seed)playerInput.playerStats.helditem,worldPos);
                playerInput.playerStats.DeleteItem(playerInput.helditem_spriterenderer);
            }
            else if(selectedtile.tileinteractable == null && playerInput.playerStats.helditem is Item)
            {
                DropItem(worldPos,playerInput,selectedtile);
                playerInput.playerStats.DeleteItem(playerInput.helditem_spriterenderer);
            }
            
            
        }
    }
    void DropItem(Vector3 pos,PlayerInput playerInput,Tile tile)
    {
        Vector3Int cellpoint = grid.WorldToCell(pos);
        Vector3 worldcellmidpoint = transform.position+cellpoint + new Vector3(0.5f,0.5f,0);
        DroppedItem droppedItem = Instantiate(farmObjects.droppeditem,pos,Quaternion.identity).GetComponent<DroppedItem>();
        droppedItem.droppeditem = playerInput.playerStats.helditem;
        tile.tileinteractable = droppedItem;
        droppedItem.transform.GetComponent<SpriteRenderer>().sprite = playerInput.playerStats.helditem.icon;
    }
}
