using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathAndOtherStuff : MonoBehaviour
{
    public static Vector2 VectorFromAngle (float theta) {
        var temp=theta* Mathf.Deg2Rad;
        Debug.Log(Mathf.Cos(temp).ToString()+","+Mathf.Sin(temp).ToString());
        return new Vector2 (Mathf.Cos(temp), Mathf.Sin(temp)); // Trig is fun
    }

    public static float AngleFrom2Point(Vector2 Start,Vector2 End)
    {
        float x=Start.x-End.x;
        float y=Start.y-End.y;
        return Mathf.Rad2Deg*Mathf.Atan2(y,x);
    }

}
