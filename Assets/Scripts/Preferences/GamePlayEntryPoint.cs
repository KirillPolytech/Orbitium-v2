using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayEntryPoint : MonoBehaviour
{
    public const string MenuSceneName = "Menu";
    public readonly InGameStateMachine InGameStateMachine = new InGameStateMachine();

    private void Awake()
    {
        GameEntryPoint.Instance.Initialize();
        InGameStateMachine.Initialize();
    }

    public void LoadMenuScene()
    {
        GameEntryPoint.LoadScene(MenuSceneName);
    }

    public void RestartScene()
    {
        GameEntryPoint.LoadScene(SceneManager.GetActiveScene().name);
    }
}