using System;
using UnityEngine;

public class InGameTime : MonoBehaviour
{
    public decimal CurrentTime { get; private set; }
    public decimal Minutes { get; private set; }
    public decimal Seconds { get; private set; }
    public decimal MiliSeconds { get; private set; }

    private MainPlayer _player;
    private void Awake()
    {
        _player = FindAnyObjectByType<MainPlayer>();
        
        CurrentTime = 0;
    }

    private void Update()
    {
        if (_player.PlayerState != Statements.Alive)
            return;

        CurrentTime += (decimal) Time.fixedDeltaTime;
        Minutes = (int) (CurrentTime / 60 % 60);
        Seconds = (int) (CurrentTime % 60);
        MiliSeconds = Math.Round(CurrentTime % 1, 1) * 100;
    }
}
