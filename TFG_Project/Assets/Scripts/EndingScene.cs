using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalText;

    private DialogueManager mainScene;
    // Start is called before the first frame update
    void Start()
    {
        mainScene = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        LoadFinalText();
    }

    private void LoadFinalText()
    {
        if(mainScene.sophia1 == true)
        {
            finalText.text = "Sophia and Ava decides to leave Peter and start fresh in another city.";
        }
        else if (mainScene.sophia2 == true)
        {
            finalText.text = "Sophia decides to leave the house with no heart feelings. She decides for the first time what's best for herself";
        }
        else if (mainScene.peter1 == true)
        {
            finalText.text = "Peter uses the excuse of smoking to leave and run away from his house. He leave and never looked back.";
        }
        else if (mainScene.peter2 == true)
        {
            finalText.text = "Peter and Ava leave the house and try their best in another city.";
        }
        else if (mainScene.goodEndingP == true || mainScene.goodEndingS == true)
        {
            finalText.text = "Ava and her parents solve all the problems that they were having. Sophia and Peter enjoy their pizza and Ava was allowed to go out with her friends and have the best night!";
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
