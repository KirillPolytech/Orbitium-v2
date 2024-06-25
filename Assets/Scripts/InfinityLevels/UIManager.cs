using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI LevelPassed;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI FPS;
    [SerializeField] private TextMeshProUGUI CollectablesText;
    [Header("Images")]
    [SerializeField] private Image StaminaImage;
    [Header("Toggles")]
    [SerializeField] private Toggle godMode;

    private FPS _fps;
    private InGameTime _inGameTime;
    private MainPlayer _player;
    private StaminaController _staminaController;
    private InGameWindowsController _inGameWindowsController;
    private GamePlayEntryPoint _gamePlayEntryPoint;
    private bool _isPauseButtonDown;
    
    public void Awake()
    {
        _player = FindAnyObjectByType<MainPlayer>();
        _staminaController = FindAnyObjectByType<StaminaController>();
        _fps = FindAnyObjectByType<FPS>();
        _inGameTime = FindAnyObjectByType<InGameTime>();
        _inGameWindowsController = FindAnyObjectByType<InGameWindowsController>();
        _gamePlayEntryPoint = FindAnyObjectByType<GamePlayEntryPoint>();

        TimeText.text = "0.0";

        _player.EventAtDeath += () => _inGameWindowsController.OpenWindow(_inGameWindowsController.GameOver);
        
        _player.EventAtCollect += UpdateCollectablesText;

        godMode.onValueChanged.AddListener( _ => { _player.SetGodMode(godMode.isOn); });


#if UNITY_WEBGL && !UNITY_EDITOR
                MainPlayer.Instance.EventAtDeath += () => { 
                YandexIntegration.Instance.SetData(new PlayerData(_timeFloat, MainPlayer.Instance.GetCollectables));
                YandexIntegration.Instance.SendDataToLeaderBoard(_timeFloat, MainPlayer.Instance.GetCollectables);
            };
#endif

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
        FPS.text = $"FPS {_fps.DeltaTime}";
    }

    private void UpdateTime()
    {
        decimal minutes = _inGameTime.Minutes;
        decimal seconds = _inGameTime.Seconds;
        decimal miliseconds = _inGameTime.MiliSeconds;
        TimeText.text = $"Time: {minutes:00}m:{seconds:00}s:{miliseconds:000}ms";
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
        CollectablesText.text = $"Orbs: {collectables}";
    }

    public void UpdatePassedLevelsCounter(int num)
    {
        LevelPassed.text = "Level: " + num;
    }
}