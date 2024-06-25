using System.Collections.Generic;

public abstract class State
{
    protected List<IStateConfigurator> _stateConfigurators;
    
    public State(List<IStateConfigurator> stateConfigurator)
    {
        _stateConfigurators = stateConfigurator;
    }
    
    public abstract void EnterState();
    public abstract void ExitState();
}