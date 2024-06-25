using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    public static GameEntryPoint Instance;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoStartGame()
    {
        Preferences.Initialize();

        Instance = new GameEntryPoint();
    }

    private void Initialize()
    {
        InGameStateMachine inGameStateMachine = new InGameStateMachine();
        inGameStateMachine.Initialize();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Instance.Initialize();
    }
}
