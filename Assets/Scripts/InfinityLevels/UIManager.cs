using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI LevelPassed;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI FPS;
    [SerializeField] private TextMeshProUGUI CollectablesText;
    [Header("Images")]
    [SerializeField] private Image StaminaImage;
    [Header("Canvases")]
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private Canvas ExitCanvas;
    [Header("Toggles")]
    [SerializeField] private Toggle GodMode;

    private FPS _fps;
    private InGameTime _inGameTime;
    private MainPlayer _player;
    
    public void Awake()
    {
        _player = FindAnyObjectByType<MainPlayer>();
        _fps = FindAnyObjectByType<FPS>();
        _inGameTime = FindAnyObjectByType<InGameTime>();

        // After Restart Settings.
        GameOverCanvas.enabled = false;
        TimeText.text = "0.0";
        //

        _player.EventAtDeath += EnableDeadScreen;
        _player.EventAtCollect += UpdateCollectablesText;

        GodMode.onValueChanged.AddListener( _ => { _player.SetGodMode(GodMode.isOn); });


#if UNITY_WEBGL && !UNITY_EDITOR
                MainPlayer.Instance.EventAtDeath += () => { 
                YandexIntegration.Instance.SetData(new PlayerData(_timeFloat, MainPlayer.Instance.GetCollectables));
                YandexIntegration.Instance.SendDataToLeaderBoard(_timeFloat, MainPlayer.Instance.GetCollectables);
            };
#endif

    }

    private void Update()
    {
        StaminaImage.fillAmount = _player.Stamina / 100;

        UpdateTime();
        UpdateFPSCounter();
        ExitScreen();
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

    public void EnableDeadScreen()
    {
        GameOverCanvas.enabled = true;
    }

    private void ExitScreen()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TimeManagement.FreezeeTime();
            ExitCanvas.enabled = true;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateCollectablesText(int collectables)
    {
        CollectablesText.text = "Orbs: " + collectables;
    }

    public void UpdatePassedLevelsCounter(int num)
    {
        LevelPassed.text = "Level: " + num;
    }
}