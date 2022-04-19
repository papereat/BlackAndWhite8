using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float TimeToReach;
    Vector3 StartingPosition;
    public Transform target;
    public Collider2D PotionCollider;
    public GameObject PotionSpill;
    public float SplashSize;
    public float SplashLifeTime;
    public float DPSIncreaseRate;
    
    void Awake()
    {
        StartingPosition=transform.position;
        StartCoroutine(PreMove());
        PotionCollider.enabled=false;

    }
    IEnumerator PreMove()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Move(0.01f));
    }
    IEnumerator Move(float Speed)
    {
        float TimeSenceStart=0;
        while (TimeSenceStart<=TimeToReach)
        {
            TimeSenceStart+=Speed;
            transform.position=StartingPosition+(target.position-StartingPosition)*(TimeSenceStart/TimeToReach);
            yield return new WaitForSeconds(Speed);
        }
        PotionCollider.enabled=true;
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        if(!Other.collider.isTrigger)
        {
            GameObject Spill=Instantiate(PotionSpill,transform.position,new Quaternion(0,0,0,0));
            Destroy(this.gameObject);
            
        }
    }
}
