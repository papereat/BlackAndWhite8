using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmov : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rb;
    public int Gold;
    public int Iron;
    public int CatFood;

    void Awake()
    {
    }
    
    void Update()
    {
        Vector2 movemnt=new Vector2(0,0);
        if(Input.GetKey(KeyCode.W))
        {
            movemnt.y=speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            movemnt.y=-speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movemnt.x=speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            movemnt.x=-speed;
        }

        rb.velocity=movemnt;

    }
}
