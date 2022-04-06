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
[Serializable]
public class RandomizedStat
{

    public Vector2 Range;
    public bool AllRaritysAreEqual;
    public List<ValueAndPercentAndPercentList> PossibleValuesAndPercent;
    public Vector2 GetStat()
    {
        if(AllRaritysAreEqual)
        {
            return new Vector2(PossibleValuesAndPercent[0].list[(int)UnityEngine.Random.Range(0,PossibleValuesAndPercent[0].list.Count)].Value,0);
        }
        else
        {
            int LootType=0;
            float ChoiceChance=UnityEngine.Random.Range(0f,1f);
            ValueAndPercentAndPercentList Choice=null;
            float PastPercent=0;
            foreach (var item in PossibleValuesAndPercent)
            {
                if(item.Percent+PastPercent>=ChoiceChance)
                {
                    Choice=item;
                    break;
                }
                LootType+=1;
                PastPercent+=item.Percent;
            }
            return new Vector2(Choice.GetValue(),LootType);

        }
        return new Vector2(0,-1);
    }
}
[Serializable]
public class ValueAndPercent
{
    public float Value;
    public float Percent;
}
[Serializable]
public class ValueAndPercentAndPercentList
{
    public List<ValueAndPercent> list;
    public float Percent;
    public float GetValue()
    {
        float ChoiceChance=UnityEngine.Random.Range(0f,1f);
        
        ValueAndPercent Choice=null;
        float PastPercent=0;
        foreach (var item in list)
        {
            if(item.Percent+PastPercent>=ChoiceChance)
            {
                Choice=item;
                break;
            }
            PastPercent+=item.Percent;
        }
        return Choice.Value;
    }
}

