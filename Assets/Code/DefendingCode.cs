 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class DefendingCode : Building
{
    public GameObject DeathScreen;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Death()
    {
        base.Death();
        DeathScreen.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene (sceneName:"Main Menu");
    }



}
