using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateStudy : MonoBehaviour
{
    public delegate void TestDelegate(int lvl, int hp, int atk);

    static int playerLvl;
    static int playerHp;
    static int playerAtk;

    static void PlusLvl(int lvl, int hp, int atk)
    {
        playerLvl += lvl;
        Debug.Log(playerLvl);
    }

    static void PlusHp(int lvl, int hp, int atk)
    {
        playerHp += hp;
        Debug.Log(playerHp);
    }

    static void PlusAtk(int lvl, int hp, int atk)
    {
        playerAtk += atk;
        Debug.Log(playerAtk);
    }

    private void Start()
    {
        TestDelegate dele = PlusLvl;
        dele += PlusHp;
        dele += PlusAtk;

        dele(10, 20, 20);   //Debug -> 10, 20, 20
        dele(20, 50, 100);  //Debug -> 30, 70, 120
    }

}
