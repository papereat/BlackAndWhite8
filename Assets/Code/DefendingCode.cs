 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class DefendingCode : Building
{
    public GameObject DeathScreen;
    public Transform Canvas;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Death()
    {
        base.Death();
        for (int i = 0; i < Canvas.childCount; i++)
        {
            Canvas.GetChild(i).gameObject.SetActive(false);
        }
        DeathScreen.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene (sceneName:"Main Menu");
    }



}
