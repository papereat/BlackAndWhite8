using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Tilemaps;

public class RatCode : MonoBehaviour
{
    
    public AIDestinationSetter Destination;
    public Transform Target;
    public Transform BuildingCollection;
    public float Health;
    public bool CanMove;
    public float Damage;
    public List<bool> isStunned;
    public float FireDamage;
    public ValueAndPercentAndPercentList Drops;
    public float debug;
    public Pmov Player;
    public List<Transform> UnreachAble;
    public GameObject HealthBar;
    public DayNightCycle DNC;
    public bool DamageAtNight;
    public int goodPriority;
    public Path path;
    public Seeker seeker;
    public Rigidbody2D rb;
    public int CurrentWaypoint;
    //public Transform Rat;


    void Awake()
    {
        StartCoroutine(fireDamage());
    }
    void Start()
    {
        HealthBar=Instantiate(HealthBar,new Vector3(transform.position.x,transform.position.y-0.25f,transform.position.z),new Quaternion(0,0,0,0),transform);
        HealthBar.GetComponent<HealthBar>().IsBuidling=false;
        HealthBar.GetComponent<HealthBar>().Rat=this.gameObject.GetComponent<RatCode>();
        SetT();
        seeker.StartPath(rb.position,Target.position,OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            CurrentWaypoint=0;
        }
    }
    void Update()
    {
        Vector2 Direction=new Vector2(0,0);
        path=seeker.GetCurrentPath();
        if(path==null)
        {
            SetT();
            seeker.StartPath(rb.position,Target.position,OnPathComplete);
        }
        Direction=((Vector2)path.vectorPath[1]-rb.position).normalized;
        int x=(int)Direction.x;
        int y=(int)Direction.y;
        Debug.Log(Direction);
        Debug.Log(x.ToString()+" "+y.ToString());
        if(isStunned.Count!=0)
        {
            CanMove=false;
        }
        else
        {
            CanMove=true;
        }

        if(Target==null)
        {
            SetT();
        }
        if(Health<=0)
        {
            Death();
        }
        //Rat.position=transform.position;
        
    }
    IEnumerator fireDamage()
    {
        while(true)
        {
            if(FireDamage>0)
            {
                if(FireDamage>=10)
                {
                    FireDamage-=10;
                    Health-=10;
                }
                else
                {
                    Health-=FireDamage;
                    FireDamage=0;
                }

            }
            yield return new WaitForSeconds(1);
        }
    }
    void SetT()
    {

        
        Transform CLosestObject=null;
        float distance=1000000;
        int priority=1000;
        foreach (Transform child in BuildingCollection)
        {
            if(priority==goodPriority)
            {
                if(child.gameObject.GetComponent<Building>().priority==goodPriority)
                {
                    if(distance>Vector3.Distance(child.position,transform.position))
                    {
                        distance=Vector3.Distance(child.position,transform.position);
                        CLosestObject=child;
                        priority=child.gameObject.GetComponent<Building>().priority;
                    }
                }
            }
            else
            {
                if(child.gameObject.GetComponent<Building>().priority==goodPriority)
                {
                    distance=Vector3.Distance(child.position,transform.position);
                    CLosestObject=child;
                    priority=child.gameObject.GetComponent<Building>().priority; 
                }
                else if(distance>Vector3.Distance(child.position,transform.position))
                {
                    distance=Vector3.Distance(child.position,transform.position);
                    CLosestObject=child;
                    priority=child.gameObject.GetComponent<Building>().priority;
                }
            }
            /*
            if(priority!=goodPriority || child.gameObject.GetComponent<Building>().priority<priority)
            {
                distance=Vector3.Distance(child.position,transform.position);
                CLosestObject=child;
                priority=child.gameObject.GetComponent<Building>().priority;
            }
            if(child.gameObject.GetComponent<Building>().priority==priority)
            {
                if(distance>Vector3.Distance(child.position,transform.position))
                {
                    distance=Vector3.Distance(child.position,transform.position);
                    CLosestObject=child;
                    priority=child.gameObject.GetComponent<Building>().priority;
                }
            }*/
        }
        Target=CLosestObject;
    }

    void Death()
    {
        Vector2 Loot=new Vector2(Random.Range(0,8),0);
        switch (Loot.y)
        {
            case 0:
                Player.Iron+=(int)Loot.x;
                break;
            case 1:
                Player.Gold+=(int)Loot.x;
                break;
        }
        Destroy(this.gameObject);
    }
    public static bool inRatList(List<RatCode> ToCheck,RatCode Check)
    {
        foreach (RatCode item in ToCheck)
        {
            if(item==Check)
            {
                return true;
            }
        }
        return false;
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        if(Other.collider.gameObject.GetComponent<Bullet>()!=null)
        {
            Bullet b=Other.collider.gameObject.GetComponent<Bullet>();
            Health-=b.Damage;
            FireDamage+=b.FireDamage;
        }
    }
}
