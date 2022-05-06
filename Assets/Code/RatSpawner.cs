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
    public float TotalAdditionCount;
    public float ToCLose;
    public float ToFar;
    public float ErrorPercentMax;
    public int SpawnArea;
    public LayerMask LM;
    public Transform BuildingCollider;
    public Pmov Player;
    public List<bool> isFar;
    public float Difficulty;
    public float DifficultyGrowthRate;
    public int StartingRats;
    public Transform RatCollection;
    public float RatsSpawned=0;
    public int LastDay=0;
    public float RatsToSpawn=0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RatSpawnCycle());
    }

    IEnumerator RatSpawnCycle()
    {
        
        var startingDifficulty=Difficulty;
        while(true)
        {
            if(LastDay!=DNC.Day)
            {
                LastDay=DNC.Day;
                Difficulty=startingDifficulty+DNC.Day*DifficultyGrowthRate;
                Debug.Log("New Day");
                RatsSpawned=0;
                Debug.Log(Mathf.Pow(StartingRats,Difficulty/10));
                RatsToSpawn=Mathf.Pow(StartingRats,Difficulty/10);
                

            }
            if(RatsToSpawn>0)
            {
                if(ForceSpawnRats)
                {
                    BoolAndVector2 test=RatSpawnLocation(10);
                    if(test.Bool)
                    {
                        SpawnRat(test.Vector);
                    }
                }
                if(!DNC.isDay)
                {
                    BoolAndVector2 test=RatSpawnLocation(10);
                    if(test.Bool)
                    {
                        SpawnRat(test.Vector);
                        RatsToSpawn-=1;
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public BoolAndVector2 RatSpawnLocation(int MaxRuns)
    {
        int count=0;
        while (count<=MaxRuns)
        {
            count+=1;
            TotalAdditionCount+=1;
            float x=Random.Range(-SpawnArea,SpawnArea);
            float y=Random.Range(-SpawnArea,SpawnArea);
            Collider2D SmallCheck=Physics2D.OverlapCircle(new Vector2(x,y),SpawnRange.x,LM);
            Collider2D BigCheck=Physics2D.OverlapCircle(new Vector2(x,y),SpawnRange.y,LM);
            ChangeSpawnSize();
            if(SmallCheck==null && BigCheck!=null)
            {
                return new BoolAndVector2(true,new Vector2(x,y));
            }
            if(SmallCheck!=null)
            {
                isFar.Add(false);
            }
            if(BigCheck==null)
            {
                isFar.Add(true);
            }
        }
        Debug.Log("Failed");
        return new BoolAndVector2(false,new Vector2(0,0));
    }
    void ChangeSpawnSize()
    {
        /*
        if(SpawnArea<=0)
        {
            SpawnArea=10;
        }
        Debug.Log("Check");
        if(TotalAdditionCount==0)
        {
            return;
        }
        Debug.Log((ToCLose/TotalAdditionCount).ToString()+" "+ToCLose.ToString()+" "+TotalAdditionCount.ToString());
        if(ToCLose/TotalAdditionCount>=ErrorPercentMax)
        {
            
            SpawnArea+=1;
        }
        else if(ToFar/TotalAdditionCount>=ErrorPercentMax)
        {
            SpawnArea-=1;
        }*/
        if(SpawnArea<=0)
        {
            SpawnArea=10;
        }
        if(isFar.Count>=10)
        {
            int farCount=0;
            int NearCOunt=0;
            foreach (bool item in isFar)
            {
                if(item)
                {
                    farCount+=1;
                }
                else
                {
                    NearCOunt+=1;
                }
            }
            if(NearCOunt>farCount)
            {
                SpawnArea+=1;
            }
            else if(farCount>NearCOunt)
            {
                SpawnArea-=1;
            }
            isFar=new List<bool>();
        }
    }
    public void SpawnRat(Vector2 Location)
    {
        GameObject RatInitiate=Instantiate(RatPrefab,new Vector3(Location.x,Location.y,0),new Quaternion(0,0,0,0),RatCollection);
        RatInitiate.GetComponent<RatCode>().Player=Player;
        RatInitiate.GetComponent<RatCode>().BuildingCollection=BuildingCollider;
        RatInitiate.GetComponent<RatCode>().DNC=DNC;
        RatInitiate.GetComponent<RatCode>().goodPriority=Random.Range(0,2);
    }
}
