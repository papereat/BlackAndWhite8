 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEditor;
 using UnityEngine.SceneManagement;

public class ceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeScent(string str)
    {
        SceneManager.LoadScene (sceneName:str);    
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}
