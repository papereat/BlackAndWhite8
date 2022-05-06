using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;
using System;

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
    public BuidlingTile CheaseTile;
    public DayNightCycle DNC;
    public Sprite[] timeImages;
    public Image SpeedImage;
    public int SpeedSetting;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(ChangeText()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(inBuildMode&&DNC.isDay)
        {
           
            if(Input.GetKey(KeyCode.Mouse1))
            {
                if(CanBuy[SelectedTile])
                {
                    Vector3Int tilemapPos = TM.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)); 
                    var DeleteTile=TM.GetTile(tilemapPos);
                    if(DeleteTile==null&&DeleteTile!=CheaseTile)
                    {
                        Debug.Log("Cake");
                        Player.Iron-=BuildableTiles[SelectedTile].Cost+2*AmountMade[SelectedTile];
                        PlaceTile();
                    }
                    
                }
                else
                {
                    NotEnough(true,Player.Iron-BuildableTiles[SelectedTile].Cost+2*AmountMade[SelectedTile]);
                }
            }
            if(Input.GetKey(KeyCode.Mouse0))
            {
                Vector3Int tilemapPos = TM.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)); 
                var DeleteTile=TM.GetTile(tilemapPos);
                if(DeleteTile!=null&&DeleteTile!=CheaseTile)
                {
                    int Index=Array.IndexOf(BuildableTiles,DeleteTile);
                    var SelectedObject=TM.GetInstantiatedObject(tilemapPos);
                    if(SelectedObject!=null)
                    {
                        Debug.Log(7);
                        var HealthBar=SelectedObject.GetComponent<Building>().HealthBarIG.GetComponent<HealthBar>();
                        Player.Iron+=(int)((HealthBar.Health/HealthBar.MaxHealth)*BuildableTiles[Index].Cost);
                    }
                    TM.SetTile(tilemapPos,null);
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
                int Index=BuildingButtons.findIndex(item);
                if(Player.Iron>=BuildableTiles[Index].Cost+2*AmountMade[Index])
                {
                    CanBuy[Index]=true;
                }
                else
                {
                    CanBuy[Index]=false;
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
    public void ChangeTimeScale()
    {
        SpeedSetting=(SpeedSetting+1)%3;
        switch (SpeedSetting)
        {
            case 0:
                Time.timeScale=0;
                SpeedImage.sprite=timeImages[SpeedSetting];
                break;
            case 1:
                Time.timeScale=1;
                SpeedImage.sprite=timeImages[SpeedSetting];
                break;
            case 2:
                Time.timeScale=2;
                SpeedImage.sprite=timeImages[SpeedSetting];
                break;
        }
    }
}
