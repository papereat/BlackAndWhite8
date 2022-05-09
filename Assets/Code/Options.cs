using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public List<GameObject> Menus;
    public int Page;
    public TileAdder TA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in Menus)
        {
            item.SetActive(false);
        }
        if(Page>=0)
        {
            Menus[0].SetActive(true);
            Menus[Page].SetActive(true);  
            Time.timeScale=0; 
        }
    }
    public void SetPage(int setTo)
    {
        Page=setTo;
        if(setTo<=-1)
        {
            TA.SetTimeScale(1);
        }
    }
    public void NextPage(int ChangeBy)
    {
        Page+=ChangeBy;
    }
}
