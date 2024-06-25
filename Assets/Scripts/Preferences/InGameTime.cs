using System;
using UnityEngine;

public class InGameTime : MonoBehaviour, IStateConfigurator
{
    private const int SecondsInMinutes = 60;
    
    public decimal CurrentTime { get; private set; }
    public decimal Minutes { get; private set; }
    public decimal Seconds { get; private set; }
    public decimal MiliSeconds { get; private set; }

    private bool _isEnabled;

    private void Update()
    {
        if (!_isEnabled)
            return;

        CurrentTime += (decimal) Time.fixedDeltaTime;
        Minutes = (int) (CurrentTime / SecondsInMinutes % SecondsInMinutes);
        Seconds = (int) (CurrentTime % SecondsInMinutes);
        MiliSeconds = Math.Round(CurrentTime % 1, 1) * 100;
    }

    public void SetState(bool state)
    {
        _isEnabled = state;
    }

    public void Reset()
    {
        CurrentTime = 0;
    }
}
