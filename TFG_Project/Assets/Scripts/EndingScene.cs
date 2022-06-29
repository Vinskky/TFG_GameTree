using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            finalText.text = "sophia1";
        }
        else if (mainScene.sophia2 == true)
        {
            finalText.text = "sophia2";
        }
        else if (mainScene.peter1 == true)
        {
            finalText.text = "peter1";
        }
        else if (mainScene.peter2 == true)
        {
            finalText.text = "peter1";
        }
        else if (mainScene.goodEnding == true)
        {
            finalText.text = "goodEnding";
        }
    }
}
