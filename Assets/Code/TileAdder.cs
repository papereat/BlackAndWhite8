using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileAdder : MonoBehaviour
{
    public Tilemap TM;
    public BuidlingTile[] BuildableTiles;
    public int[] AmountMade;
    public Pmov Player;
    public int SelectedTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectedTile!=-1)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                if(Player.Iron>=Player.Iron-BuildableTiles[SelectedTile].Cost+2*AmountMade[SelectedTile])
                {
                    PlaceTile();
                }
                else
                {
                    NotEnough(true,Player.Iron-BuildableTiles[SelectedTile].Cost+2*AmountMade[SelectedTile]);
                }
            }
        }
    }
    void NotEnough(bool isIron, int AmountNeeded)
    {
        
    }
    void PlaceTile()
    {
        Vector3Int tilemapPos = TM.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)); 
        TM.SetTile(tilemapPos,BuildableTiles[SelectedTile]);
    }
}
