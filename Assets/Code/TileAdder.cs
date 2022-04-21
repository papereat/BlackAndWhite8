using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;

public class TileAdder : MonoBehaviour
{
    
    public Tilemap TM;
    public BuidlingTile[] BuildableTiles;
    public GameObject[] BuildingButtons;
    public TextMeshProUGUI[] BuildingPriceText;
    public bool[] CanBuy;
    public int[] AmountMade;
    public Pmov Player;
    public int SelectedTile;
    public bool inBuildMode;
    public Color CanAffordColor;
    public Color CantAffordColor;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(ChangeText()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(inBuildMode)
        {
           
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                if(CanBuy[SelectedTile])
                {
                    Player.Iron-=BuildableTiles[SelectedTile].Cost+2*AmountMade[SelectedTile];
                    PlaceTile();
                }
                else
                {
                    NotEnough(true,Player.Iron-BuildableTiles[SelectedTile].Cost+2*AmountMade[SelectedTile]);
                }
            }
        }
    }
    IEnumerator ChangeText()
    {
        while (true)
        {
            foreach (var item in BuildingButtons)
            {
                //Debug.Log(BuildableTiles[AmountMade.findIndex(item)].name);
                if(Player.Iron>=BuildableTiles[BuildingButtons.findIndex(item)].Cost+2*AmountMade[BuildingButtons.findIndex(item)])
                {
                    CanBuy[BuildingButtons.findIndex(item)]=true;
                }
                else
                {
                    CanBuy[BuildingButtons.findIndex(item)]=false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                BuildingPriceText[i].text="$"+(BuildableTiles[i].Cost+2*AmountMade[i]).ToString();
                if(CanBuy[i])
                {
                    BuildingPriceText[i].color=CanAffordColor;
                }
                else
                {
                    BuildingPriceText[i].color=CantAffordColor;
                }
            }
            yield return new WaitForSeconds(.1f);
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
