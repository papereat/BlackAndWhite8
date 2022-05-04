using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public float Speed;
    public float Time;
    public bool isPaused;
    public bool isDay;
    public int Day;
    public Transform UI;
    public Button SkipDay;
    public Button SkipNight;
    public RatSpawner RS;


    void Start()
    {
      StartCoroutine(StartCycle(0.1f));
    }
    public float DayPercent()
    {
        return Time/24;
    }
    public void SetTime(float SetTo)
    {
        if(SetTo<=Time)
        {
            Day+=1;
        }
        Time=SetTo%24;
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
            var rotationVector = UI.rotation.eulerAngles;
            rotationVector.z = -360*(Time/24)+90;
            UI.rotation = Quaternion.Euler(rotationVector);
            isDay=Time<=12;
            SkipDay.interactable=isDay;
            if(!isDay&&RS.RatsToSpawn<1)
            {
                SkipNight.interactable=true;
            }
            else
            {
                SkipNight.interactable=false;
            }
            yield return new WaitForSeconds(RunsEvry);
        }
    }
}
