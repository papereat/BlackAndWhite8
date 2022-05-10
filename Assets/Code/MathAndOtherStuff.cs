using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Extensions
{
    public static int findIndex<T>(this T[] array, T item) {
        return Array.IndexOf(array, item);
    }
}
public class MathAndOtherStuff : MonoBehaviour
{
    public static Vector2 VectorFromAngle (float theta) {
        var temp=theta* Mathf.Deg2Rad;
        return new Vector2 (Mathf.Cos(temp), Mathf.Sin(temp)); // Trig is fun
    }

    public static float AngleFrom2Point(Vector2 Start,Vector2 End)
    {
        float x=Start.x-End.x;
        float y=Start.y-End.y;
        return Mathf.Rad2Deg*Mathf.Atan2(y,x);
    }

    public static void DebugList(List<float> list)
    {
        string debugLog="";
        int currentNum=0;
        foreach (var item in list)
        {
            debugLog+=currentNum.ToString()+": "+item.ToString()+", ";
            currentNum+=1;
        }
        Debug.Log(debugLog);
    }
    public static int RoundFloat(float round)
    {
        bool Negitive= round<0;
        int WholeNum=(int)round;
        float Decimal=round-WholeNum;
        if(Negitive)
        {
            Decimal=Decimal*-1;
        }
        if(Decimal>=.5)
        {
            if(Negitive)
            {
                WholeNum-=1;
            }
            else
            {
            WholeNum+=1;
            }
        }
        return WholeNum;
    }

}
