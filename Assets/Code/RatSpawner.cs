using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RatSpawner : MonoBehaviour
{
    public Vector2 SpawnRange;
    public bool DontSpawnRats;
    public bool ForceSpawnRats;
    public DayNightCycle DNC;
    public GameObject RatPrefab;
    public Tilemap TM;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RatSpawnCycle());
    }

    IEnumerator RatSpawnCycle()
    {
        while(true)
        {
            if(ForceSpawnRats)
            {
                SpawnRat(RatSpawnLocation(10));
                continue;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    BoolAndVector3 RatSpawnLocation(int MaxRuns)
    {
        int count=0;
        while (count<=MaxRuns)
        {
            count+=1
            x=Random.Range(-50,50);
            y=Random.Range(-50,50);
            Collider2D Checker
        }
    }

    void SpawnRat(Vector2 Location)
    {
        
    }
}
