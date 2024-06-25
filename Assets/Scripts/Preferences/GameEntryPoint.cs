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
    
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void Initialize()
    {
        Preferences.Initialize();
        
        InGameStateMachine inGameStateMachine = new InGameStateMachine();
        inGameStateMachine.Initialize();
    }
}