using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla : Building
{
    public bool CanAttack;
    public Collider2D AttackCollider;
    public ContactFilter2D CF;
    public float AttackSpeed;
    public float StunTime;
    public float Damage;
    

    void Start()
    {
        StartCoroutine(Shoots());
    }

    IEnumerator Shoots()
    {
        while(true)
        {
            if(CanAttack)
            {
                List<Collider2D> ColliderLists=new List<Collider2D>();

                AttackCollider.OverlapCollider(CF,ColliderLists);
                if(ColliderLists.Count>0)
                {
                    foreach (Collider2D item in ColliderLists)
                    {
                        item.gameObject.GetComponent<RatCode>().Health-=Damage;
                        StartCoroutine(Stuns(item.gameObject.GetComponent<RatCode>()));
                    }
                }
            }
            yield return new WaitForSeconds(AttackSpeed);
        }
    }

    IEnumerator Stuns(RatCode RC)
    {
        int x=0;
        while(x<=1)
        {
            if(x==0)
            {
                RC.isStunned.Add(true);
            }
            else
            {
                RC.isStunned.Remove(true);
            }
            x+=1;
            yield return new WaitForSeconds(StunTime);
        }
    }
}
