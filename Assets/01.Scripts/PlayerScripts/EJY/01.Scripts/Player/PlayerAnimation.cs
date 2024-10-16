using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IPlayerComponent
{
    private Players _player;
    public Animator AnimaCompo { get; private set; }

    public void Initialize(Players player)
    {
        _player = player;
        AnimaCompo = GetComponent<Animator>();
    }
}
