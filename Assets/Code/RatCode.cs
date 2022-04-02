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
    //public Transform Rat;

    void Update()
    {
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
