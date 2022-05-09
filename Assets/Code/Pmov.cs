using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pmov : MonoBehaviour
{
    
    public float speed;
    public Rigidbody2D rb;
    public int Gold;
    public int Iron;
    public TextMeshProUGUI IronCount;
    public int CatFood;
    public Vector2 StartingMousePos;

    void Awake()
    {
    }
    
    void Update()
    {
        IronCount.text="Iron: "+Iron.ToString();

        Vector2 movemnt=new Vector2(0,0);
        /*
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
        */

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartingMousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 CurrentMousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movemnt=StartingMousePos-CurrentMousePos;
        }

        transform.position+=new Vector3(movemnt.x,movemnt.y,0);

    }
}
