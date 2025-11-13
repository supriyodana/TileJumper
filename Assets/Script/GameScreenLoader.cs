using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenLoader : MonoBehaviour
{
    public GameObject instructionPanel;

    public GameObject SettingBtn;
    public GameObject SettingPanel;

    private bool isOpen = false;

    void Start()
    {
        // instructionPanel.SetActive(false);
        SettingBtn.SetActive(true);
        SettingPanel.SetActive(false);
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

    public void settingsBtnClick()
    {
        if (isOpen == false)
        {
            SettingBtn.SetActive(false);
            SettingPanel.SetActive(true);
            isOpen = true;
        }


    }

    public void confirmBtnClick()  //in settings panel
    {
        if (isOpen == true)
        {
            SettingPanel.SetActive(false);
            SettingBtn.SetActive(true);
            isOpen = false;
        }
    }


}
