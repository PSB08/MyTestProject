using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject panel;

    private void Update()
    {
        if (dialogueManager.CheckFinishDialogue(true))
        {
            panel.SetActive(false);

        }
    }

    private IEnumerator ShowEffect()
    {
        yield return new WaitForSeconds(0.1f);
    }

}
