using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public bool IsBuidling;
    public Gradient gradient;
    public bool AlwaysShow;
    public SpriteRenderer[] SRs;
    public Building Build;
    public RatCode Rat;
    public float Health;
    public float MaxHealth;
    public bool Hide;
    public bool ShowWithFullHP;
    // Start is called before the first frame update
    void Awake()
    {
        if(IsBuidling)
        {
            MaxHealth=Build.Health;
        }
        else
        {
            MaxHealth=Rat.Health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsBuidling)
        {
            Health=Build.Health;
        }
        else
        {
            Health=Rat.Health;
        }
        if(Hide || MaxHealth-1>=Health && !ShowWithFullHP)
        {
            foreach(SpriteRenderer item in SRs)
            {
                item.enabled=false;
            }
        }
        else
        {
           foreach (SpriteRenderer item in SRs)
           {
               item.enabled=true;
           } 
           SRs[0].color=gradient.Evaluate(Health/MaxHealth);
        }
    }
}
