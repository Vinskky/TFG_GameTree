using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject tutorialPanel; 
    [SerializeField] private GameObject introPanel; 
    [SerializeField] private GameObject creditsPanel; 
    public void IntroButton()
    {
        introPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        creditsPanel.SetActive(true);
    }

    public void BackCreditsButton()
    {
        creditsPanel.SetActive(false);
    }

    public void LinkdIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/devar-sebastian/");
    }

    public void Github()
    {
        Application.OpenURL("https://github.com/Vinskky/TFG_GameTree");
    }

    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ControlsButton()
    {
        tutorialPanel.SetActive(true);
    }

    public void BackFromControlsButton()
    {
        tutorialPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
