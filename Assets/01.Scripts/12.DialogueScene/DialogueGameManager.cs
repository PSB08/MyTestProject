using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VHierarchy.Libs;

public class DialogueGameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (dialogueManager.CheckFinishDialogue(true))
        {
            panel.SetActive(false);

        }
    }

    public void StartDialogue()
    {
        panel.SetActive(true);
    }

}
