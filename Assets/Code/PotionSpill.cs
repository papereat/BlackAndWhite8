using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpill : MonoBehaviour
{
    public ContactFilter2D CF;
    public Collider2D AttackCollider;
    public float StartingDamage;
    public float DPSIncreaseRate;
    public float LifeTime;
    public float SplashSize;
    public float SplashLifeTime;

    void Awake()
    {
        transform.localScale=new Vector3(SplashSize,SplashSize,0);
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
            LifeTime+=Speed;
            Debug.Log(increaseAmount);
            if(LifeTime>=SplashLifeTime)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(Speed);
        }
    }
}
