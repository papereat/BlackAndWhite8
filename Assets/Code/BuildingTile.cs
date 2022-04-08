using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class BuidlingTile : TileBase
{
    public Sprite sprite;
    public Color cl;
    public GameObject SpawnObject;
    public GameObject SpawnedObject;
    public Vector3Int LocationM;
    public Vector3 LocationG;
    public Tilemap TM;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = sprite;
        tileData.color = cl;
        tileData.gameObject=SpawnObject;
        LocationM=position;
    } 

    public void OnDisable()
    {
        DestroyImmediate(SpawnedObject);
    }


}

