using System;
using UnityEngine;

public class InGameTime : MonoBehaviour
{
    public decimal GetTime => _timeFloat;

    private int _minutes, _seconds;
    private decimal _miliSeconds;
    private decimal _timeFloat;

    private MainPlayer _player;
    private UIManager UI;
    private void Awake()
    {
        _player = FindAnyObjectByType<MainPlayer>();
        UI = FindAnyObjectByType<UIManager>();
    }

    private void Start()
    {
        _timeFloat = 0;
    }

    private void Update()
    {
        if (_player.GetPlayerState != Statements.Alive)
            return;

        _timeFloat += (decimal) Time.fixedDeltaTime;
        _minutes = (int) (_timeFloat / 60 % 60);
        _seconds = (int) (_timeFloat % 60);
        _miliSeconds = Math.Round(_timeFloat % 1, 1) * 100;

        UI.UpdateTime(_minutes, _seconds, _miliSeconds);
    }
}
