using KoreanTyper;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("SerializeField")]
    [SerializeField] private TextMeshProUGUI textLocated;
    [SerializeField] private List<string> dialogues;
    [SerializeField] private List<string> characterNames;
    [SerializeField] private GameObject cap;
    [SerializeField] private Button autoBtn;
    [SerializeField] private Camera main;
    [Header("Private UI")]
    private Image buttonImage;
    [Header("Private Value")]
    private int currentDialogueIndex = 0;
    private bool isTyping;
    private bool isAutoDialogue = false;
    private bool isFinished = false;
    private bool isTalking = true;
    [Header("Manager and Coroutine")]
    private CharacterManager characterManager;
    private Coroutine typingCoroutine;
    private Coroutine autoDialogueCoroutine;

    private void Start()
    {
        isAutoDialogue = false;
        isFinished = false;
        isTalking = true;
        textLocated.text = "�����̽� �ٷ� ��ȭ ����.";
        cap.SetActive(false);
    }

    private void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        buttonImage = autoBtn.GetComponent<Image>();
    }

    private void Update()
    {
        if (isTalking == false) return;
        if (isAutoDialogue == true) return;
        if (Input.GetKeyDown(KeyCode.Space))
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

    /// <summary>
    /// ���� ��ȭ �����ִ� �޼���
    /// </summary>
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
            main.backgroundColor = Color.gray;
        }
    }

    /// <summary>
    /// ���� ��ȭ ���� �����ִ� �޼���
    /// </summary>
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
            FinishedTalking();
        }
    }

    /// <summary>
    /// ��ȭ Ÿ�����ϴ� �޼���
    /// </summary>
    /// <param name="characterName"></param>
    /// <param name="dialogue"></param>
    /// <returns></returns>
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

    /// <summary>
    /// ��ȭ ��ŵ �޼���
    /// </summary>
    public void SkipDialogue()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            FinishedTalking();
        }
    }

    /// <summary>
    /// ��ȭ�� �������� Ȯ���ϴ� �޼���
    /// </summary>
    /// <param name="finished"></param>
    /// <returns></returns>
    public bool CheckFinishDialogue(bool finished)
    {
        return isFinished;
    }

    /// <summary>
    /// �̾߱� ������ üũ�ϴ� �޼���
    /// </summary>
    /// <param name="talking"></param>
    /// <returns></returns>
    public bool CheckTalking(bool talking)
    {
        return isTalking;
    }

    /// <summary>
    /// �ڵ����� �����ϴ� �޼���
    /// </summary>
    public void ToggleAutoDialogue()
    {
        Color origin = Color.white;
        Color changed = Color.yellow;
        isAutoDialogue = !isAutoDialogue;

        if (isAutoDialogue)
        {
            buttonImage.color = changed;
            if (autoDialogueCoroutine == null)
            {
                autoDialogueCoroutine = StartCoroutine(AutoDialogueCoroutine());
            }
        }
        else
        {
            isAutoDialogue = false;
            buttonImage.color = origin;
            if (autoDialogueCoroutine != null)
            {
                StopCoroutine(autoDialogueCoroutine);
                autoDialogueCoroutine = null;
            }
        }

    }

    /// <summary>
    /// �ڵ� ��ȭ �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    private IEnumerator AutoDialogueCoroutine()
    {
        for (int i = currentDialogueIndex; i < dialogues.Count; i++)
        {
            while (isTyping)
            {
                yield return null; 
            }
            yield return new WaitForSeconds(1f);
            ShowNextDialogue();
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(2f);
        FinishedTalking();

    }

    /// <summary>
    /// �̾߱� ������ �� �͵�
    /// </summary>
    private void FinishedTalking()
    {
        isFinished = true;
        isTalking = false;
        textLocated.text = "";
        cap.SetActive(true);
    }

}
