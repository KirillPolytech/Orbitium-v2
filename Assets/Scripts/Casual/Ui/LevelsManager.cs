using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private GameObject _selectLevelCanvas;

    private static GameObject[] _availableLevels = new GameObject[35];
    private static int[] _isLevelDone = new int[35];

    private GameObject _availableLevelsGameObject;
    private AvailableLevels _availableLevelsScript;

    private static GameObject[] _levelsScore = new GameObject[35];
    private static GameObject[] _levelsTime = new GameObject[35];
    private void Awake()
    {
        GetLevelsScore();
        GetLevelsTime();
        SetLevelsScore();
        SetLevelsTime();

        for (int i = 0; i < 35; i++)
        {
            if (i < 3)
                _isLevelDone[i] = 1;
        }

        _availableLevelsGameObject = GameObject.Find("AvailableLevels(DontDestroryOnLoad)");
        _availableLevelsScript = _availableLevelsGameObject.GetComponent<AvailableLevels>();

        int[] isleveldone = _availableLevelsScript.GetLevelConditions();

        for (int i = 3; i < 30; i++)
            _isLevelDone[i] = isleveldone[i];

        GetLevels();
    }
    private void GetLevels()
    {
        _selectLevelCanvas.SetActive(true);
        for (int i = 0; i < 30; i++)
        {
            _availableLevels[i] = GameObject.Find(Convert.ToString(i + 2)); // получаем 2-21 уровнень.
            if (_availableLevels[i] && _isLevelDone[i + 2] == 0)
            {
                _availableLevels[i].GetComponent<Button>().enabled = false;
                _availableLevels[i].GetComponent<Image>().color = new Color(0, 0, 0);
            }
        }
        _selectLevelCanvas.SetActive(false);
    }
    private void GetLevelsScore()
    {
        _selectLevelCanvas.SetActive(true);

        int z = 1;
        for (int i = 0; i < 35; i++, z++)
        {
            if (GameObject.Find("Score " + Convert.ToString(z)))
            {
                _levelsScore[i] = GameObject.Find("Score " + Convert.ToString(z));
            }
        }

        _selectLevelCanvas.SetActive(false);
    }
    private void GetLevelsTime()
    {
        _selectLevelCanvas.SetActive(true);

        int z = 1;
        for (int i = 0; i < 35; i++, z++)
        {
            if (GameObject.Find("Time " + Convert.ToString(z)))
            {
                _levelsTime[i] = GameObject.Find("Time " + Convert.ToString(z));
            }
        }

        _selectLevelCanvas.SetActive(false);
    }
    private void SetLevelsScore()
    {
        _selectLevelCanvas.SetActive(true);

        int z = 1;
        for (int i = 0; i < 35; i++, z++)
        {
            if (_levelsScore[i])
            {
                _levelsScore[i].GetComponent<TextMeshProUGUI>().text = "Score: " + LevelsData.GetLevelData(i + 2).Score;                
            }
        }

        _selectLevelCanvas.SetActive(false);
    }
    private void SetLevelsTime()
    {
        _selectLevelCanvas.SetActive(true);

        int z = 1;
        for (int i = 0; i < 35; i++, z++)
        {
            if (_levelsTime[i])
            {                
                _levelsTime[i].GetComponent<TextMeshProUGUI>().text = "Time: " + Math.Round( LevelsData.GetLevelData(i + 2).Time, 1 );
            }
        }

        _selectLevelCanvas.SetActive(false);
    }
}