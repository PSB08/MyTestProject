using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DelegateStudy : MonoBehaviour
{
    public TextMeshProUGUI lvlTxt;
    public TextMeshProUGUI hpTxt;
    public TextMeshProUGUI atkTxt;

    public int myLvl;
    public int myHp;
    public int myAtk;

    public delegate void TestDelegate(int lvl, int hp, int atk);

    static int playerLvl;
    static int playerHp;
    static int playerAtk;

    static void PlusLvl(int lvl, int hp, int atk)
    {
        playerLvl += lvl;
    }

    static void PlusHp(int lvl, int hp, int atk)
    {
        playerHp += hp;
    }

    static void PlusAtk(int lvl, int hp, int atk)
    {
        playerAtk += atk;
    }

    private void Start()
    {
        TestDelegate dele = PlusLvl;
        dele += PlusHp;
        dele += PlusAtk;

        dele(myLvl, myHp, myAtk);
        lvlTxt.text = playerLvl.ToString();
        hpTxt.text = playerHp.ToString();
        atkTxt.text = playerAtk.ToString();
    }

}
