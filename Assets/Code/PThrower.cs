using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PThrower : Building
{
    public bool CanAttack;
    public GameObject Potion;
    public Transform target;
    public Collider2D AttackCollider;
    public float Range;
    public float TimeToReach;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(Shoots());
    }
    IEnumerator Shoots()
    {
        while(true)
        {
            if(CanAttack)
            {
                if(target==null || Vector3.Distance(target.position,transform.position)>Range)
                {
                    target=null;
                    List<Collider2D> ColliderLists=new List<Collider2D>();
                    AttackCollider.OverlapCollider(CFB,ColliderLists);
                    if(ColliderLists.Count>1)
                    {
                        target=ColliderLists[0].transform;
                    }
                    else
                    {
                        continue;
                    }

                }
                if(target==null)
                {
                    continue;    
                }
                else
                {
                    GameObject bullet=Instantiate(Potion,transform.position,new Quaternion(0,0,0,0));
                    bullet.GetComponent<Potion>().TimeToReach=TimeToReach;
                    bullet.GetComponent<Potion>().target=target;
                }
            }
            yield return new WaitForSeconds(15);
        }
    }
}
