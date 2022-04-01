using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float Health=100;
    public Collider2D CD;

    public void Damage(float Damage)
    {
        Health-=Damage;
        if(Health<=0)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        Debug.Log("te");
        if(CD.IsTouchingLayers(6))
        {
            Debug.Log("test");
            Damage(5*Time.deltaTime);
        }

        
    }
}
