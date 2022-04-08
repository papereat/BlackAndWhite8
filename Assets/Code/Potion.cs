using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float TimeToReach;
    Vector3 StartingPosition;
    public Transform target;

    
    void Awake()
    {
        StartingPosition=transform.position;
        StartCoroutine(Move(.01f));
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
        
    }
}
