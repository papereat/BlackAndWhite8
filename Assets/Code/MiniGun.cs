using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : Building
{
    
    public bool CanAttack;
    public GameObject Bullet;
    public float Angle;
    public Transform BulletSpawn;
    public Transform BulletCollection;
    public float AttackSpeed;
    public float SprayRange;
    public ContactFilter2D CF;
    public Vector3 test;



    void Start()
    {
        StartCoroutine(Shoots());
    }
    void Update()
    {
        List<Collider2D> ColliderLists=new List<Collider2D>();
       
        CF.layerMask=PlayerMask;
        TakeDamage.OverlapCollider(CF,ColliderLists);
        if(ColliderLists.Count>0)
        {
           
           Angle = MathAndOtherStuff.AngleFrom2Point(transform.position,ColliderLists[0].transform.position);
        }
        transform.eulerAngles=new Vector3(0,0,Angle);

        

    }

    IEnumerator Shoots()
    {
        while(true)
        {
            if(CanAttack)
            {
                GameObject bullet=Instantiate(Bullet,BulletSpawn.position,new Quaternion(0,0,0,0));
                bullet.GetComponent<Bullet>().Angle=Angle+Random.Range(-SprayRange,SprayRange);
            }
            yield return new WaitForSeconds(AttackSpeed);
        }
    }
}
