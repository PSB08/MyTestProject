using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTextScripts : MonoBehaviour
{
    public Text text;

    public string[] tutorial;
    public string[] dialogue;

    public int talkNum;

    private void Start()
    {
        StartTalk(tutorial);
    }

    IEnumerator Typing(string talk)
    {
        text.text = null;
        text.DOText(talk, 1f);
        text.DOColor(Color.red, 23f);
        yield return new WaitForSeconds(3f);
        NextTalk();
    }

    public void StartTalk(string[] talks)
    {
        dialogue = talks;

        StartCoroutine(Typing(dialogue[talkNum]));
    }

    public void NextTalk()
    {
        talkNum++;

        if (talkNum == dialogue.Length)
        {
            EndTalk();
            return;
        }

        StartCoroutine(Typing(dialogue[talkNum]));

    }   
    
    public void EndTalk()
    {
        talkNum = 0;

        Debug.Log("³¡");
    }

}
