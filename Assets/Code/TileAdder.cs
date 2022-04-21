using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TileAdder : MonoBehaviour
{
    public Tilemap TM;
    public BuidlingTile[] BuildableTiles;
    public GameObject[] BuildingButtons;
    public Text[] BuildingPriceText;
    public int[] AmountMade;
    public Pmov Player;
    public int SelectedTile;
    public bool inBuildMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inBuildMode)
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
    public void ChangeSet(int i)
    {
        SelectedTile=i;
    }
    public void toggleButtons()
    {
        foreach (var item in BuildingButtons)
        {
            item.SetActive(!item.activeSelf);
            inBuildMode=item.activeSelf;
        }
    }
    
    void PlaceTile()
    {
        Vector3Int tilemapPos = TM.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)); 
        TM.SetTile(tilemapPos,BuildableTiles[SelectedTile]);
    }
}
