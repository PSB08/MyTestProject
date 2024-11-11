using KoreanTyper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myText;
    [SerializeField] private List<string> dialogues;
    [SerializeField] private List<string> characterNames;
    private int currentDialogueIndex = 0;
    private CharacterManager characterManager;
    private Coroutine typingCoroutine;
    private bool isTyping;

    private void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
        if (currentDialogueIndex < dialogues.Count)
        {
            Debug.Log(currentDialogueIndex);
            Debug.Log(dialogues.Count);
            string characterName = characterNames[currentDialogueIndex - 1];
            myText.text = $"{characterName}: {dialogues[currentDialogueIndex - 1]}";
            isTyping = false;
        }
        if (currentDialogueIndex == dialogues.Count)
        {
            Debug.Log(currentDialogueIndex);
            Debug.Log(dialogues.Count);
            string characterName = characterNames[currentDialogueIndex - 1];
            myText.text = $"{characterName}: {dialogues[currentDialogueIndex - 1]}";
            isTyping = false;
        }
    }

    private void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            string characterName = characterNames[currentDialogueIndex];
            characterManager.UpdateCharacterImages(characterName);
            typingCoroutine = StartCoroutine(Typing(characterName, dialogues[currentDialogueIndex]));
            currentDialogueIndex++;
        }
        else
        {
            Debug.Log("다이얼로그가 끝났습니다.");
            myText.text = "";
        }
    }

    private IEnumerator Typing(string characterName, string dialogue)
    {
        string fullText = $"{characterName}: {dialogue}";
        myText.text = "";
        isTyping = true;

        for (int i = 0; i < fullText.Length; i++)
        {
            myText.text += fullText[i];
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
    }
}
