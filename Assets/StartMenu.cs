using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DieOut.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private SceneField _sampleScene;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScenesAsync(_sampleScene.SceneName);
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
