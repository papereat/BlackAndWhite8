using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpill : MonoBehaviour
{
    public ContactFilter2D CF;
    public Collider2D AttackCollider;
    public float StartingDamage;
    public float DPSIncreaseRate;
    public float lifeTime=0;
    public float MaxLifetime;

    void Awake()
    {
        StartCoroutine(SpillEffect(.1f));
    }

    IEnumerator SpillEffect(float Speed)
    {
        float increaseAmount=1;
        while (true)
        {
            List<Collider2D> ColliderLists=new List<Collider2D>();
            AttackCollider.OverlapCollider(CF,ColliderLists);
            foreach (var item in ColliderLists)
            {
                item.gameObject.GetComponent<RatCode>().Health-=StartingDamage*increaseAmount*Speed;
            }
            increaseAmount=increaseAmount*(increaseAmount+DPSIncreaseRate*Speed);
            lifeTime+=Speed;
            Debug.Log(increaseAmount);
            if(lifeTime>=MaxLifetime)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(Speed);
        }
    }
}
