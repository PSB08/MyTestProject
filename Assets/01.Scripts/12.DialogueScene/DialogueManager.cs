using KoreanTyper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textLocated;
    [SerializeField] private List<string> dialogues;
    [SerializeField] private List<string> characterNames;
    [SerializeField] private GameObject cap;
    private int currentDialogueIndex = 0;
    private CharacterManager characterManager;
    private Coroutine typingCoroutine;
    private bool isTyping;
    //Test
    private bool isFinished = false;
    private bool isTalking = true;

    private void Start()
    {
        textLocated.text = "";
        cap.SetActive(false);
    }

    private void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
    }

    private void Update()
    {
        if (isTalking == false) return;
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                DisplayCurrentDialogue();
            }
            else
            {
                ShowNextDialogue();
            }
        }
    }

    private void DisplayCurrentDialogue()
    {
        if (isTalking == false) return;
        if (currentDialogueIndex < dialogues.Count)
        {
            string characterName = characterNames[currentDialogueIndex - 1];
            textLocated.text = $"{characterName} : {dialogues[currentDialogueIndex - 1]}";
            isTyping = false;
        }
        if (currentDialogueIndex == dialogues.Count)
        {
            string characterName = characterNames[currentDialogueIndex - 1];
            textLocated.text = $"{characterName} : {dialogues[currentDialogueIndex - 1]}";
            isTyping = false;
            cap.SetActive(true);
        }
    }

    private void ShowNextDialogue()
    {
        if (isTalking == false) return;
        if (currentDialogueIndex < dialogues.Count)
        {
            string characterName = characterNames[currentDialogueIndex];
            characterManager.UpdateCharacterImages(characterName);
            typingCoroutine = StartCoroutine(Typing(characterName, dialogues[currentDialogueIndex]));
            currentDialogueIndex++;
        }
        else
        {
            isFinished = true;
            isTalking = false;
            textLocated.text = "";
            cap.SetActive(true);
        }
    }

    private IEnumerator Typing(string characterName, string dialogue)
    {
        string fullText = $"{characterName} : {dialogue}";
        textLocated.text = "";
        isTyping = true;

        int typingLength = fullText.GetTypingLength(); 

        for (int i = 0; i <= typingLength; i++)
        {
            textLocated.text = fullText.Typing(i);
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
    }

    public void SkipDialogue()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            isFinished = true;
            isTalking = false;
            textLocated.text = "";
        }
    }

    public bool CheckFinishDialogue(bool finished)
    {
        return isFinished;
    }

    public bool CheckTalking(bool talking)
    {
        return isTalking;
    }



}
