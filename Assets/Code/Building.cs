using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
    public float Health=100;
    public Collider2D TakeDamage;
    public Tile tile;
    public ContactFilter2D CFB;
    


    public void Damage(float Damage)
    {
        Health-=Damage;
        Debug.Log("in D UP");
        if(Health<=0)
        {
            Debug.Log("NoBOm");
            Destroy(this.gameObject);
        }
    }

    

    void Update()
    {
        Debug.Log("At UP");

        List<Collider2D> ColliderLists=new List<Collider2D>();

        TakeDamage.OverlapCollider(CFB,ColliderLists);
        if(ColliderLists.Count>0)
        {
            foreach (Collider2D item in ColliderLists)
            {
                if(item.gameObject.GetComponent<RatCode>().CanMove)
                {
                    Damage(item.gameObject.GetComponent<RatCode>().Damage*Time.deltaTime);
                }
                
            }
        }

        
    }
}
