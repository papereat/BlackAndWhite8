using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BoolAndVector2
{
    public bool Bool;
    public Vector2 Vector;

    public BoolAndVector2(bool Bool,Vector3 Vector)
    {
        this.Bool=Bool;
        this.Vector=Vector;
    }
}