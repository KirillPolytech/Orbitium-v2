using System.Collections.Generic;

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
    }

    public override void ExitState()
    {
        
    }
}
