using System.Collections.Generic;

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
    }

    public override void ExitState()
    {
        
    }
}
