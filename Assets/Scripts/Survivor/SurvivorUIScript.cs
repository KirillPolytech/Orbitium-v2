using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SurvivorUIScript : MonoBehaviour
{
    public GameObject WinCanvas;
    public GameObject GameOverCanvas;
    public GameObject QuitCanvas;

    public TextMeshProUGUI FPS;
    public TextMeshProUGUI SizeText;
    public Image StaminaImage;
    public Toggle GodMode;

    public int WinScale = 800;

    private GameObject _playerGameObject;
    private SurvivorPlayer _survivorPlayer;
    private SuvivorAddForceOnDrag _survivalAddForceOnDrag;

    private float deltaTime;
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _survivalAddForceOnDrag = _playerGameObject.GetComponent<SuvivorAddForceOnDrag>();
        _survivorPlayer = _playerGameObject.GetComponent<SurvivorPlayer>();

        // After Restart Settings.
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        //
    }
    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        FPS.text = "FPS: " + (int)(1.0f / deltaTime);

        _survivorPlayer.SetGodMode(GodMode.isOn);

        ExitScreenOn();
    }
    private void FixedUpdate()
    {
        DeadScreen();
        WinScreen();
        SizeCounter();

        StaminaImage.fillAmount = _survivorPlayer.GetStamina() / 100;
    }
    private void DeadScreen()
    {
        if (_survivorPlayer.IsDeadStatement() && _survivorPlayer.IsWinStatement() == false)
        {
            GameOverCanvas.SetActive(true);

            _survivalAddForceOnDrag.SetLinePositionToZero();
            _survivalAddForceOnDrag.enabled = false;
        }
    }
    private void WinScreen()
    {
        if (_survivorPlayer.IsWinStatement() && _survivorPlayer.IsDeadStatement() == false)
        {
            WinCanvas.SetActive(true);

            _survivalAddForceOnDrag.SetLinePositionToZero();
            _survivalAddForceOnDrag.enabled = false;
        }
    }
    private void SizeCounter()
    {
        SizeText.text = "Size: " + (int)_survivorPlayer.GetSize();
    }
    private void ExitScreenOn()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TimeScaleToToZero();
            QuitCanvas.SetActive(true);
        }
    }
    public void TimeScaleToToZero()
    {
        Time.timeScale = 0;
    }
    public void TimeScaleToToNormal()
    {
        Time.timeScale = 1;
    }
}
// Camera.main.GetComponent<CameraTracking>().Line.enabled = false;