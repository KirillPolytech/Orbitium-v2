using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InGameStateMachine : StateMachine
{
    public ActiveState ActiveState { get; private set; }
    public PauseState PauseState { get; private set; }

    private InGameTime _inGameTime;
    private MainPlayer _mainPlayer;
    private DragMovement _dragMovement;
    private InGameWindowsController _inGameWindowsController;

    [Inject]
    public void Construct(MainPlayer mainPlayer, InGameTime inGameTime, DragMovement dragMovement, InGameWindowsController
        inGameWindowsController)
    {
        _inGameTime = inGameTime;
        _mainPlayer = mainPlayer;
        _dragMovement = dragMovement;
        _inGameWindowsController = inGameWindowsController;

        List<IStateConfigurator> iStateConfigurator = new List<IStateConfigurator>
        {
            _inGameTime,
            _mainPlayer,
            _dragMovement
        };

        ActiveState = new ActiveState(iStateConfigurator);
        PauseState = new PauseState(iStateConfigurator);

        _mainPlayer.EventAtDeath += () =>
        {
            SetState(PauseState);
            _inGameWindowsController.OpenWindow(_inGameWindowsController.GameOver);
        };

        SetState(ActiveState);
    }
}