using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[CustomEditor(typeof(Tilemap))]
public class TileMapEditor : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        Tilemap tm=(Tilemap)target;

        if(GUILayout.Button("Refresh Tiles"))
        {
            tm.RefreshAllTiles();
        }
    }
}
