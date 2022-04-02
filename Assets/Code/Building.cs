using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
    public float Health=100;
    public Collider2D TakeDamage;
    public Tile tile;
    public LayerMask damageFrom;
    public LayerMask PlayerMask;


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

        if(TakeDamage.IsTouchingLayers(damageFrom))
        {
            Debug.Log("At D");
            Damage(5*Time.deltaTime);
        }

        
    }
}
