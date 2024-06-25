using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [Header("Texts")] 
    [SerializeField] private TextMeshProUGUI levelPassed;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI fps;
    [SerializeField] private TextMeshProUGUI collectablesText;
    [Header("Images")] [SerializeField] private Image StaminaImage;
    [Header("Toggles")] [SerializeField] private Toggle godMode;

    private FPS _fps;
    private InGameTime _inGameTime;
    private MainPlayer _player;
    private StaminaController _staminaController;
    private InGameWindowsController _inGameWindowsController;
    private GamePlayEntryPoint _gamePlayEntryPoint;
    private BlackScreen _blackScreen;
    private bool _isPauseButtonDown;

    public void Awake()
    {
        _player = FindAnyObjectByType<MainPlayer>();
        _staminaController = FindAnyObjectByType<StaminaController>();
        _fps = FindAnyObjectByType<FPS>();
        _inGameTime = FindAnyObjectByType<InGameTime>();
        _inGameWindowsController = FindAnyObjectByType<InGameWindowsController>();
        _gamePlayEntryPoint = FindAnyObjectByType<GamePlayEntryPoint>();
        _blackScreen = FindAnyObjectByType<BlackScreen>();

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
        StaminaImage.fillAmount = _staminaController.StaminaNormalized;

        UpdateTime();
        UpdateFPSCounter();
        HandleInput();
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
            _gamePlayEntryPoint.InGameStateMachine.SetState(_gamePlayEntryPoint.InGameStateMachine.PauseState);
            _inGameWindowsController.OpenWindow(_inGameWindowsController.Quit);
        }
        else
        {
            _gamePlayEntryPoint.InGameStateMachine.SetState(_gamePlayEntryPoint.InGameStateMachine.ActiveState);
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