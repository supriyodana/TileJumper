using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenLoader : MonoBehaviour
{
    public GameObject instructionPanel;
    
    void Start()
    {
        // instructionPanel.SetActive(false);
    }

    void Update()
    {

    }

    public void ShowPanel()
    {
        instructionPanel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    

}
