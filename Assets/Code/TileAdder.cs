using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileAdder : MonoBehaviour
{
    public Tilemap TM;
    public TileBase[] BuildableTiles;
    public Pmov Player;
    public int SelectedTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int tilemapPos = TM.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)); 
        TM.SetTile(tilemapPos,BuildableTiles[SelectedTile]);
    }
}
