using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RatSpawner))]
public class RatSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        RatSpawner RS=(RatSpawner)target;

        if (GUILayout.Button("Check Location"))
        {
            BoolAndVector2 test=RS.RatSpawnLocation(10);

            Debug.Log(test.Bool);
            Debug.Log(test.Vector.x);
            Debug.Log(test.Vector.y);
        }
        if (GUILayout.Button("Spawn Rat"))
        {
            BoolAndVector2 test=RS.RatSpawnLocation(10);
            if(test.Bool)
            {
                RS.SpawnRat(test.Vector);
            }
            
        }
    }
}
