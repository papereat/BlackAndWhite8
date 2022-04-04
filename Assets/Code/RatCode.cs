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
    public AstarPath NG;
    public AIPath AP;
    public bool CanMove;
    public float Damage;
    public List<bool> isStunned;
    //public Transform Rat;

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

    public void SetT()
    {
        NG.Scan();
        
        Transform CLosestObject=null;
        float distance=1000000;
        foreach (Transform child in BuildingCollection)
        {
            if(distance>Vector3.Distance(child.position,transform.position))
            {
                distance=Vector3.Distance(child.position,transform.position);
                CLosestObject=child;
            }
        }
        Destination.target=CLosestObject;
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        if(Other.collider.gameObject.GetComponent<Bullet>()==true){}
        {
            Bullet b=Other.collider.gameObject.GetComponent<Bullet>();
            Health-=b.Damage;
        }
    }
}
