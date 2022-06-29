using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private TextMeshProUGUI displayNameText;

    [SerializeField] private Animator portraitAnimator;
    private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private static DialogueManager instance;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set;}

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string POINTS_AVASOPHIA_TAG = "as_points";
    private const string POINTS_AVAPETER_TAG = "ap_points";
    private const string SOPHIA_LOSE = "sLose";
    private const string PETER_LOSE = "pLose";

    private int sophiaPoints;
    private int peterPoints;

    //bools for final scene
    [HideInInspector]
    public bool sophia1 = false;
    [HideInInspector]
    public bool sophia2 = false;
    [HideInInspector]
    public bool peter1 = false;
    [HideInInspector]
    public bool peter2 = false;
    [HideInInspector]
    public bool goodEnding = false;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue manager in the scene");
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        //weight system initialization
        sophiaPoints = 50;
        peterPoints = 50;

        //get the layout animator
        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            ContinueStory();
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        //restart portrait, layouot, and speaker
        displayNameText.text = "???";
        portraitAnimator.Play("default");
        layoutAnimator.Play("right");


        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //set text for the current dialogue line
            dialogueText.text = currentStory.Continue();

            //display choices, if any, for this dialogue line
            DisplayChoices();

            //handle tags

            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //loop through each tag and handle it accordingly
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            //Switch to handle each specific tag
            switch(tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case POINTS_AVASOPHIA_TAG:
                    sophiaPoints += int.Parse(tagValue);
                    break;
                case POINTS_AVAPETER_TAG:
                    peterPoints += int.Parse(tagValue);
                    break;
                case PETER_LOSE:
                    if (int.Parse(tagValue) == 0) { peter1 = true; } //Peter lose screen, stay with mom
                    else { peter2 = true; }                          //Peter lose screen, go with dad
                    //Load ending scene
                    SceneManager.LoadScene("EndScreen");
                    break;
                case SOPHIA_LOSE:
                    if (int.Parse(tagValue) == 0) { sophia1 = true; }   // Sophia lose screen, stay with mom
                    else { sophia2 = true; }                            //Sophia lose screen, go with dad
                    //Load ending scene
                    SceneManager.LoadScene("EndScreen");
                    break;
                default:
                    Debug.LogWarning("Tag came in but ius not currently being handled: " + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " 
                + currentChoices.Count);
        }

        int index = 0;

        //enable and initizalize choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    public int GetSophiaPoints()
    {
        return sophiaPoints;
    }

    public int GetPeterPoints()
    {
        return peterPoints;
    }
}
