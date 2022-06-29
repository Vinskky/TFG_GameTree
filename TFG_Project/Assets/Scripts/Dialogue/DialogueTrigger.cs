using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset introText;
    [SerializeField] private TextAsset goodText;
    [SerializeField] private TextAsset badText;
    [SerializeField] private TextAsset defaultText;

    [Header("Ink JSON")]
    [SerializeField] private GameObject dialogueManager;

    private bool playerInRange;
    private DialogueManager scriptDialogue;

    //intro just once
    private static bool introSophiaDone;
    private static bool introPeterDone;
    private static bool goodSophiaDone;
    private static bool goodPeterDone;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        scriptDialogue = dialogueManager.GetComponent<DialogueManager>();
        
    }
 

    private void Update()
    {
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(gameObject.name == "NPC_1") //Sophia
                {
                    DialogueManager.GetInstance().EnterDialogueMode(HandleSophiaDialogues());
                }
                else if(gameObject.name == "NPC_2")
                {
                    DialogueManager.GetInstance().EnterDialogueMode(HandlePeterDialogues());
                }
                
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

        //Win condition
        WinningScreen();
    }


    private void WinningScreen()
    {
        if (scriptDialogue.GetPeterPoints() >= 70 && scriptDialogue.GetSophiaPoints() >= 70 
            && goodPeterDone == true && goodSophiaDone == true && scriptDialogue.goodEndingP == true && scriptDialogue.goodEndingS == true)
        {
            //Add delay to read last part of dialogue
            new WaitForSeconds(5);
            //load end escene
            SceneManager.LoadScene("EndScreen");

            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Entering collider space");
            playerInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Exit collider space");
            playerInRange = false;
        }
    }

    private TextAsset HandlePeterDialogues()
    {
        if(scriptDialogue.GetPeterPoints() <= 30 && introSophiaDone == true)
        {
            return badText;
        }
        else if (scriptDialogue.GetPeterPoints() >= 70 && introSophiaDone == true)
        {
            goodPeterDone = true;
            return goodText;
        }
        else if(introPeterDone == false)
        {
            introPeterDone = true;
            return introText;
        }
        else 
        {
            return defaultText;
        }
    }

    private TextAsset HandleSophiaDialogues()
    {
        if (scriptDialogue.GetSophiaPoints() <= 30 && introPeterDone == true)
        {
            return badText;
        }
        else if (scriptDialogue.GetSophiaPoints() >= 70 && introPeterDone == true)
        {
            goodSophiaDone = true;
            return goodText;
        }
        else if (introSophiaDone == false)
        {
            introSophiaDone = true;
            return introText;
        }
        else
        {
            return defaultText;
        }
    }
}
