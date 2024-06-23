using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtons : MonoBehaviour
{
    private AvailableLevels _avilableLevels;
    private UIScript _scriptUI;
    private int _currentSceneIndex = -99;
    
    private void Awake()
    {
        _scriptUI = FindAnyObjectByType<UIScript>();
        _avilableLevels = FindAnyObjectByType<AvailableLevels>();

        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    public void NextButton()
    {
        _avilableLevels.UnlockLevel(_currentSceneIndex + 1);
        LevelsData.SetLevelData(Score.GetScore(_currentSceneIndex), _scriptUI.GetTime(), _currentSceneIndex);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }
}