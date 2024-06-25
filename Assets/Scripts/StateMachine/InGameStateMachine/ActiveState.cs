using System.Collections.Generic;
using UnityEngine;

public class ActiveState : State
{
    public ActiveState(List<IStateConfigurator> stateConfigurator) : base(stateConfigurator)
    {
        
    }
    
    public override void EnterState()
    {
        foreach(var state in _stateConfigurators)
        {
            state.SetState(true);
        }

        Time.timeScale = 1;
    }

    public override void ExitState()
    {
        
    }
}
