using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Angle;
    public float lifeTime;
    float Temp=0;
    public float Damage;
    public Rigidbody2D rb;
    public float bulletSpeed;


    void Update()
    {
        transform.eulerAngles=new Vector3(0,0,Angle);


        Temp+=Time.deltaTime;
        if(Temp>lifeTime)
        {
            Destroy(this.gameObject);
        }

        rb.velocity=MathAndOtherStuff.VectorFromAngle(Angle)*bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if(!Other.collider.isTrigger)
        {
            Destroy(this.gameObject);
        }
    }
}
