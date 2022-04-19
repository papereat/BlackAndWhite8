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
        
        StartCoroutine(SpillEffect(.01f));
    }

    IEnumerator SpillEffect(float Speed)
    {

        float increaseAmount=1;
        while (true)
        {
            Debug.Log(SplashSize);
            transform.localScale=new Vector3(SplashSize,SplashSize,1);
            List<Collider2D> ColliderLists=new List<Collider2D>();
            AttackCollider.OverlapCollider(CF,ColliderLists);
            foreach (var item in ColliderLists)
            {
                item.gameObject.GetComponent<RatCode>().Health-=StartingDamage*increaseAmount*increaseAmount*Speed;
            }
            increaseAmount=increaseAmount+DPSIncreaseRate*Speed;
            LifeTime+=Speed;
            Debug.Log(increaseAmount);
            Debug.Log(LifeTime<=SplashLifeTime);
            if(LifeTime>SplashLifeTime && SplashLifeTime!=0)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(Speed);
        }
    }
}
