using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void BackToStartMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
