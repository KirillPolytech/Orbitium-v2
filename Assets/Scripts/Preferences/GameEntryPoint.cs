using UnityEngine;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoStartGame()
    {
        Preferences.Initialize();

        _instance = new GameEntryPoint();
        _instance.Initialize();
    }

    private void Initialize()
    {
        
    }
}
