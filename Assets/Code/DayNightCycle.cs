using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float Speed;
    public float Time;
    public bool isPaused;
    public bool isDay;
    public int Day;
    public Transform UI;


    void Start()
    {
      StartCoroutine(StartCycle(0.1f));
    }
    public float DayPercent()
    {
        return Time/24;
    }
    IEnumerator StartCycle(float RunsEvry)
    {
        while (true)
        {
            if(!isPaused)
            {
                Time+=Speed*RunsEvry;
            }
            if(Time>24)
            {
                Time=Time-24;
                Day+=1;
                
            }
            UI.localRotation=new Quaternion(0,0,Time,0);
            isDay=Time<=12;
            yield return new WaitForSeconds(RunsEvry);
        }
    }
}
