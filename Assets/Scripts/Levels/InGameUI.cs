using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelPassed;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI fps;
    [SerializeField] private TextMeshProUGUI collectablesText;
    [SerializeField] private Image StaminaImage;
    [SerializeField] private Toggle godMode;

    private MainPlayer _player;
    private FPS _fps;
    private InGameTime _inGameTime;
    private StaminaController _staminaController;
    private InGameWindowsController _inGameWindowsController;
    private BlackScreen _blackScreen;
    private InGameStateMachine _inGameStateMachine;
    private bool _isPauseButtonDown;

    [Inject]
    public void Construct(MainPlayer player, StaminaController staminaController, FPS fps, InGameTime inGameTime,
        InGameWindowsController inGameWindowsController, BlackScreen blackScreen,
        InGameStateMachine inGameStateMachine
    )
    {
        _player = player;
        _staminaController = staminaController;
        _fps = fps;
        _inGameTime = inGameTime;
        _inGameWindowsController = inGameWindowsController;
        _blackScreen = blackScreen;
        _inGameStateMachine = inGameStateMachine;

        Initialize();
    }

    private void Initialize()
    {
        timeText.text = "0.0";
        _player.EventAtDeath += () => _inGameWindowsController.OpenWindow(_inGameWindowsController.GameOver);
        _player.EventAtCollect += UpdateCollectablesText;
        godMode.onValueChanged.AddListener(_ => { _player.SetGodMode(godMode.isOn); });

#if UNITY_WEBGL && !UNITY_EDITOR
                MainPlayer.Instance.EventAtDeath += () => { 
                YandexIntegration.Instance.SetData(new PlayerData(_timeFloat, MainPlayer.Instance.GetCollectables));
                YandexIntegration.Instance.SendDataToLeaderBoard(_timeFloat, MainPlayer.Instance.GetCollectables);
            };
#endif
    }

    private void Start()
    {
        _blackScreen.SetColor(new Color(0, 0, 0, 1));
        _blackScreen.Disable();
    }

    private void Update()
    {
        UpdateStamina();
        UpdateTime();
        UpdateFPSCounter();
        HandleInput();
    }

    private void UpdateStamina()
    {
        StaminaImage.fillAmount = _staminaController.StaminaNormalized;
    }

    private void UpdateFPSCounter()
    {
        fps.text = $"FPS {_fps.DeltaTime}";
    }

    private void UpdateTime()
    {
        decimal minutes = _inGameTime.Minutes;
        decimal seconds = _inGameTime.Seconds;
        decimal miliseconds = _inGameTime.MiliSeconds;
        timeText.text = $"Time: {minutes:00}m:{seconds:00}s:{miliseconds:000}ms";
    }

    private void HandleInput()
    {
        if (!Input.GetKeyDown(GlobalVariables.Exit))
            return;

        ChangeExitScreenState();
    }

    public void ChangeExitScreenState()
    {
        _isPauseButtonDown = !_isPauseButtonDown;

        if (_isPauseButtonDown)
        {
            _inGameStateMachine.SetState(_inGameStateMachine.PauseState);
            _inGameWindowsController.OpenWindow(_inGameWindowsController.Quit);
        }
        else
        {
            _inGameStateMachine.SetState(_inGameStateMachine.ActiveState);
            _inGameWindowsController.OpenWindow(_inGameWindowsController.Main);
        }
    }

    private void UpdateCollectablesText(int collectables)
    {
        collectablesText.text = $"Orbs: {collectables}";
    }

    public void UpdatePassedLevelsCounter(int num)
    {
        levelPassed.text = $"Level: {num}";
    }
}