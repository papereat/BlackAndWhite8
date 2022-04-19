using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Angle;
    public float lifeTime;
    float Temp=0;
    public float Damage;
    public float FireDamage;
    public Rigidbody2D rb;
    public float bulletSpeed;
    public int EnemyCount;
    public int MaxEnemyCount;
    public Collider2D AttackCollider;
    public ContactFilter2D CF;
    public List<RatCode> AttackedRats;


    void Update()
    {
        transform.eulerAngles=new Vector3(0,0,Angle);


        Temp+=Time.deltaTime;
        if(Temp>lifeTime)
        {
            Destroy(this.gameObject);
        }
        List<Collider2D> ColliderLists=new List<Collider2D>();
        AttackCollider.OverlapCollider(CF,ColliderLists);
        foreach (var item in ColliderLists)
        {
            if(!item.isTrigger)
            {
                if( item.gameObject.layer==7 && !RatCode.inRatList(AttackedRats,item.gameObject.GetComponent<RatCode>()))
                {
                    AttackedRats.Add(item.gameObject.GetComponent<RatCode>());
                    item.gameObject.GetComponent<RatCode>().Health-=Damage;
                    item.gameObject.GetComponent<RatCode>().FireDamage+=FireDamage;
                    EnemyCount+=1;
                    if(MaxEnemyCount>=EnemyCount && item.gameObject.layer==7)
                    {
                        return;
                    }
                }
                
                Destroy(gameObject);
            }
        }
        rb.velocity=MathAndOtherStuff.VectorFromAngle(Angle)*bulletSpeed;
    }
}
