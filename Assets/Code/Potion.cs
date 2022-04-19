using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float TimeToReach;
    Vector3 StartingPosition;
    public Transform target;
    public GameObject PotionSpill;
    public float SplashSize;
    public float SplashLifeTime;
    public float DPSIncreaseRate;
    public Vector3 LastLocation;
    
    void Awake()
    {
        StartingPosition=transform.position;
        StartCoroutine(PreMove());

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
            if(target!=null)
            {
                LastLocation=target.position;
                transform.position=StartingPosition+(target.position-StartingPosition)*(TimeSenceStart/TimeToReach);
            }
            else
            {
                transform.position=StartingPosition+(LastLocation-StartingPosition)*(TimeSenceStart/TimeToReach);
            }
            
            yield return new WaitForSeconds(Speed);
        }
        GameObject Spill=Instantiate(PotionSpill,transform.position,new Quaternion(0,0,0,0));
        Spill.GetComponent<PotionSpill>().SplashSize=SplashSize;
        Spill.GetComponent<PotionSpill>().SplashLifeTime=SplashLifeTime;
        Spill.GetComponent<PotionSpill>().DPSIncreaseRate=DPSIncreaseRate;
        Destroy(this.gameObject);
    }
}
