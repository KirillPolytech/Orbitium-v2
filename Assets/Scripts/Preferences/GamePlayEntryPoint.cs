using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        GameEntryPoint.Instance.Initialize();
    }

    public void LoadGame()
    {
        GameEntryPoint.Instance.LoadScene(SceneNamesStorage.AutoGeneratedLevelsSceneName);
    }

    public void LoadMenuScene()
    {
        GameEntryPoint.Instance.LoadScene(SceneNamesStorage.MenuSceneName);
    }

    public void RestartScene()
    {
        GameEntryPoint.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }
}