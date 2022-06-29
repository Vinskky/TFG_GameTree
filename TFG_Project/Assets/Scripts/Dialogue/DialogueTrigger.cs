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
    private bool introSophiaDone;
    private bool introPeterDone;


    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        scriptDialogue = dialogueManager.GetComponent<DialogueManager>();
        introSophiaDone = false;
        introPeterDone = false;

    }

    private void Update()
    {
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(HandleDialogues());
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

        //Win condition
        if(scriptDialogue.GetPeterPoints() > 70 && scriptDialogue.GetSophiaPoints() > 70)
        {
            //win condition active
            scriptDialogue.goodEnding = true;
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

    private TextAsset HandleDialogues()
    {
        if(scriptDialogue.GetPeterPoints() <= 30 && gameObject.name == "NPC_2" && introSophiaDone == true)
        {
            return badText;
        }
        else if (scriptDialogue.GetPeterPoints() > 70 && gameObject.name == "NPC_2" && introSophiaDone == true)
        {
            return goodText;
        }
        else if(introPeterDone == false)
        {
            introPeterDone = true;
            return introText;
        }
        else if(gameObject.name == "NPC_2" && introPeterDone == true && introSophiaDone == false)
        {
            return defaultText;
        }
        else if (scriptDialogue.GetSophiaPoints() <= 30 && gameObject.name == "NPC_1" && introPeterDone == true)
        {
            return badText;
        }
        else if (scriptDialogue.GetSophiaPoints() > 70 && gameObject.name == "NPC_1" && introPeterDone == true)
        {
            return goodText;
        }
        else if (introSophiaDone == false)
        {
            introSophiaDone = true;
            return introText;
        }
        else if (gameObject.name == "NPC_1" && introSophiaDone == true && introPeterDone == false)
        {
            return defaultText;
        }
        return default;
    }
}
