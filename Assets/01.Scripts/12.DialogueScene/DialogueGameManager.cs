using System.Collections;
using UnityEngine;

public class DialogueGameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject capsule;


    private void Start()
    {
        capsule.SetActive(false);
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
        if (dialogueManager.CheckTalking(true))
        {
            dialogueManager.SkipDialogue();
            capsule.SetActive(true);
        }
    }

    private IEnumerator ShowEffect()
    {
        yield return new WaitForSeconds(0.1f);
    }

    public void AutoBtn()
    {
        if (dialogueManager.CheckTalking(true))
        {
            dialogueManager.ToggleAutoDialogue();
        }
    }


}
