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

    private void Update()
    {
        if (dialogueManager.CheckFinishDialogue(true))
        {
            panel.Destroy();

        }
    }

}
