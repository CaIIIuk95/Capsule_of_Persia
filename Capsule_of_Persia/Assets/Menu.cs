using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Menu_Button, MenuWindow;
    public MonoBehaviour[] ScriptsToDeactivate;


    public void Start()
    {
        
        OpenMenuWindow();
    }

    public void OpenMenuWindow()
    {
        
        Menu_Button.SetActive(false);
        MenuWindow.SetActive(true);
        for (int i = 0; i < ScriptsToDeactivate.Length; i++)
        {
            ScriptsToDeactivate[i].enabled=false;
        }
        Time.timeScale=0.0001f;
        
    }

    public void CloseMenuWindow()
    {
        Menu_Button.SetActive(true);
        MenuWindow.SetActive(false);
        for (int i = 0; i < ScriptsToDeactivate.Length; i++)
        {
            ScriptsToDeactivate[i].enabled=true;
        }
        Time.timeScale=1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
