using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject cap;

    private void Start()
    {
        cap.SetActive(false);
    }

    private void Update()
    {
        if (dialogueManager.CheckFinishDialogue(true))
        {
            panel.SetActive(false);
        }

    }

    public void SkipBtn()
    {
        if (dialogueManager.CheckTalking(false))
        {
            dialogueManager.SkipDialogue();
            cap.SetActive(true);
        }
    }

    private IEnumerator ShowEffect()
    {
        yield return new WaitForSeconds(0.1f);
    }

}
