using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    public static GameEntryPoint Instance;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoStartGame()
    {
        Instance = new GameEntryPoint();
    }

    public void Initialize()
    {
        Preferences.Initialize();
        
        InGameStateMachine inGameStateMachine = new InGameStateMachine();
        inGameStateMachine.Initialize();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Instance.Initialize();
    }
}