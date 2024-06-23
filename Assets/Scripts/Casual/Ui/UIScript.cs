using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI TimeText;
    public TextMeshProUGUI FPS;

    public TextMeshProUGUI CollectablesText;

    public Image StaminaImage;

    public GameObject WinCanvas;
    public GameObject GameOverCanvas;
    public GameObject ExitCanvas;

    public Toggle GodMode;

    private GameObject _playerGameObject;
    private DragMovement _dragMovement;
    private Player _player;

    private float deltaTime;
    private float _timeFloat;
    private int __minutes, __seconds;
    private double __miliSeconds;
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _dragMovement = _playerGameObject.GetComponent<DragMovement>();
        _player = _playerGameObject.GetComponent<Player>();

        // After Restart Settings.
        WinCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        TimeText.text = "0.0";
        _timeFloat = 0;
        //
    }
    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        FPS.text = "FPS: " + (int)(1.0f / deltaTime);

        ExitScreen();

        _player.SetGodMode(GodMode.isOn);
    }
    private void FixedUpdate()
    {
        DeadScreen();
        WinScreen();

        CollectablesCounter();
        UpdateScore();
        TimeUpdate();

        StaminaImage.fillAmount = _player.Stamina / 100;
    }
    private void TimeUpdate()
    {
        if (!_player.IsWin )
        {
            _timeFloat += Time.fixedDeltaTime;
            __minutes = (int)(_timeFloat / 60 % 60);
            __seconds = (int)(_timeFloat % 60);
            __miliSeconds = Math.Round(_timeFloat % 1, 1) * 100;//Math.Round(_timeFloat % 100, 2);
            TimeText.text = "Time: " + __minutes + "m:" + __seconds + "s" + ":" + __miliSeconds + "ms";
            //Debug.Log(_timeFloat);
        }
    }
    private void DeadScreen()
    {
        if ( _player.IsDead && !_player.IsWin)
        {
            GameOverCanvas.SetActive(true);

            _dragMovement.SetLinePositionToZero();
            _dragMovement.enabled = false;
        }
    }
    private void WinScreen()
    {
        if (_player.IsWin && !_player.IsDead )
        {
            WinCanvas.SetActive(true);

            _dragMovement.SetLinePositionToZero();
            _dragMovement.enabled = false;
        }
    }
    private void ExitScreen()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TimeManagement.FreezeeTime();
            ExitCanvas.SetActive(true);
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void CollectablesCounter()
    {
        CollectablesText.text = "" + _player.Collectables + " / " + CollectablesManager.GetCountOfCollectables();
    }

    public void UpdateScore()
    {
        _scoreText.text = "Score: " + Score.GetScore(SceneManager.GetActiveScene().buildIndex);
    }
    public float GetTime()
    {
        return _timeFloat;
    }
}
// Camera.main.GetComponent<CameraTracking>().Line.enabled = false;

/*
public void TimeScaleToToZero()
{
    Time.timeScale = 0;
}
public void TimeScaleToToNormal()
{
    Time.timeScale = 1;
}
*/