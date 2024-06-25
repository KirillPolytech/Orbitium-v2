using System.Collections.Generic;
using UnityEngine;

public class InGameStateMachine : StateMachine
{
    public ActiveState ActiveState { get; private set; }
    public PauseState PauseState { get; private set; }

    private InGameTime _inGameTime;
    private MainPlayer _mainPlayer;
    private DragMovement _dragMovement;
    private InGameWindowsController _inGameWindowsController;

    public void Initialize()
    {
        _inGameTime = Object.FindAnyObjectByType<InGameTime>();
        _mainPlayer = Object.FindAnyObjectByType<MainPlayer>();
        _dragMovement = Object.FindAnyObjectByType<DragMovement>();
        _inGameWindowsController = Object.FindAnyObjectByType<InGameWindowsController>();

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