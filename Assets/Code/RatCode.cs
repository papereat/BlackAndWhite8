using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Tilemaps;

public class RatCode : MonoBehaviour
{
    
    public AIDestinationSetter Destination;
    public Transform BuildingCollection;
    public float Health;
    public AIPath AP;
    public bool CanMove;
    public float Damage;
    public List<bool> isStunned;
    public float FireDamage;
    public RandomizedStat Drops;
    public float debug;
    public Pmov Player;
    public List<Transform> UnreachAble;
    
    //public Transform Rat;


    void Awake()
    {
        StartCoroutine(fireDamage());
    }
    void Update()
    {
        if(isStunned.Count!=0)
        {
            CanMove=false;
        }
        else
        {
            CanMove=true;
        }
        AP.canMove=CanMove;
        if(Destination.target==null)
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
            if(child.gameObject.GetComponent<Building>().priority<priority)
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
            }
        }
        Destination.target=CLosestObject;
    }

    void Death()
    {
        Vector2 Loot=Drops.GetStat();
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
