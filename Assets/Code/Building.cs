using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class Building : MonoBehaviour
{
    public float Health=100;
    public Collider2D TakeDamage;
    public TileBase tile;
    public ContactFilter2D CFB;
    public int priority;
    public AstarPath AP;
    WorldStatHolder WSH;


    public void Damage(float Damage)
    {
        Health-=Damage;
        if(Health<=0)
        {
            Death();
        }
    }

    IEnumerator CheckIfDamage()
    {
        while (true)
        {
            List<Collider2D> ColliderLists=new List<Collider2D>();

            TakeDamage.OverlapCollider(CFB,ColliderLists);
            if(ColliderLists.Count>0)
            {
                foreach (Collider2D item in ColliderLists)
                {
                    if(item.gameObject.GetComponent<RatCode>().CanMove)
                    {
                        Damage(item.gameObject.GetComponent<RatCode>().Damage*.05f);
                    }
                    
                }
            }
            yield return new WaitForSeconds(.05f);
        }
    }

    protected virtual void Awake()
    {
        StartCoroutine(CheckIfDamage());
        WSH=FindObjectOfType<WorldStatHolder>();
        AP=WSH.AP;
    }
    void Death()
    {
        Collider2D[] CollidersToOff=GetComponents<Collider2D>();
        foreach (var item in CollidersToOff)
        {
            item.enabled=false;
        }
        AP.Scan();
        Destroy(this.gameObject);
    }
}
