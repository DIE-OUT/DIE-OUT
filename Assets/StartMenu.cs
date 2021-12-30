using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
