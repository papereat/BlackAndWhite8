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

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(Shoots());
    }
    IEnumerator Shoots()
    {
        while (true)
        {
            if(CanAttack)
            {
                if(target==null || Vector3.Distance(target.position,transform.position)>Range)
                {
                    List<Collider2D> ColliderLists=new List<Collider2D>();
                    AttackCollider.OverlapCollider(CFB,ColliderLists);
                    target=ColliderLists[0].transform;
                }

                
            }
        }
    }
}
