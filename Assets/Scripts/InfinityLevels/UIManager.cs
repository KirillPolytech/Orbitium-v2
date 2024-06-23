using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI LevelPassed;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI FPS;
    [SerializeField] private TextMeshProUGUI CollectablesText;
    [Header("Images")]
    [SerializeField] private Image StaminaImage;
    [Header("Canvases")]
    [SerializeField] private Canvas WinCanvas;
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private Canvas ExitCanvas;
    [Header("Toggles")]
    [SerializeField] private Toggle GodMode;

    private MainPlayer _player;
    public void Initialize()
    {
        if (Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);

        _player = FindObjectOfType<MainPlayer>();

        // After Restart Settings.
        WinCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        TimeText.text = "0.0";
        //

        _player.EventAtDeath += EnableDeadScreen;

        GodMode.onValueChanged.AddListener( (bool x) => { _player.SetGodMode(GodMode.isOn); });


#if UNITY_WEBGL && !UNITY_EDITOR
                MainPlayer.Instance.EventAtDeath += () => { 
                YandexIntegration.Instance.SetData(new PlayerData(_timeFloat, MainPlayer.Instance.GetCollectables));
                YandexIntegration.Instance.SendDataToLeaderBoard(_timeFloat, MainPlayer.Instance.GetCollectables);
            };
#endif

    }

    private void Update()
    {
        StaminaImage.fillAmount = _player.GetStamina / 100;

        ExitScreen();
    }

    public void UpdateFPSCounter(float time)
    {
        FPS.text = "FPS: " + (int)(1.0f / time);
    }

    public void UpdateTime(decimal minutes, decimal seconds, decimal miliseconds)
    {
        TimeText.text = "Time: " + minutes + "m:" + seconds + "s" + ":" + miliseconds + "ms";
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