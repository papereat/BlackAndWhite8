using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UpgradableStat 
{
    public List<float> Values;
    public int Level;

    public float CurrentValue()
    {
        return Values[Level];
    }
    public void Upgrade()
    {
        Level+=1;
    }
}
