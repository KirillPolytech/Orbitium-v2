using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIInfinityScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI FPS;

    [SerializeField] private TextMeshProUGUI CollectablesText;

    [SerializeField] private Image StaminaImage;

    [SerializeField] private GameObject WinCanvas;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject ExitCanvas;

    [SerializeField] private Toggle GodMode;

    private GameObject _playerGameObject;
    private DragMovement _dragMovement;
    private Player _player;

    private float _deltaTime;
    private float _timeFloat;
    private int _minutes, _seconds;
    private double _miliSeconds;
    
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
        _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
        FPS.text = "FPS: " + (int)(1.0f / _deltaTime);

        ExitScreen();

        _player.SetGodMode(GodMode.isOn);
    }
    
    private void FixedUpdate()
    {
        DeadScreen();
        WinScreen();

        UpdateCollectablesText();
        UpdateScore();
        TimeUpdate();

        StaminaImage.fillAmount = _player.Stamina / 100;
    }
    
    private void TimeUpdate()
    {
        if (!_player.IsWin )
        {
            _timeFloat += Time.fixedDeltaTime;
            _minutes = (int)(_timeFloat / 60 % 60);
            _seconds = (int)(_timeFloat % 60);
            _miliSeconds = Math.Round(_timeFloat % 1, 1) * 100;//Math.Round(_timeFloat % 100, 2);
            TimeText.text = "Time: " + _minutes + "m:" + _seconds + "s" + ":" + _miliSeconds + "ms";
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
        if (!_player.IsWin || _player.IsDead) 
            return;
        
        WinCanvas.SetActive(true);

        _dragMovement.SetLinePositionToZero();
        _dragMovement.enabled = false;
    }
    
    private void ExitScreen()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) 
            return;
        
        TimeManagement.FreezeeTime();
        ExitCanvas.SetActive(true);
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    private void UpdateCollectablesText()
    {
        CollectablesText.text = "" + _player.Collectables;
    }

    private void UpdateScore()
    {
        _scoreText.text = "Score: " + Score.GetScore(SceneManager.GetActiveScene().buildIndex);
    }
    
    public float GetTime()
    {
        return _timeFloat;
    }
}