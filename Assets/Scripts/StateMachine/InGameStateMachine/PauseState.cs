using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    public PauseState(List<IStateConfigurator> iStateConfigurator) : base(iStateConfigurator)
    {
       
    }

    public override void EnterState()
    {
        foreach(var state in _stateConfigurators)
        {
            state.SetState(false);
        }

        Time.timeScale = 0;
    }

    public override void ExitState()
    {
        
    }
}
