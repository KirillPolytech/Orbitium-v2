using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    public static GameEntryPoint Instance;

    private AsyncOperation _operation;
    private Loading _loading;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoStartGame()
    {
        Instance = new GameEntryPoint();
    }

    private GameEntryPoint()
    {
        _loading = Resources.Load<Loading>("LoadingPrefab");
        _loading = Object.Instantiate(_loading);
        Object.DontDestroyOnLoad(_loading);

        LoadScene(SceneNamesStorage.MenuSceneName);
    }

    public void LoadScene(string sceneName)
    {
        _loading.SetVisibility(true);
        
        SceneManager.LoadScene(SceneNamesStorage.BootSceneName);

        _loading.StartLoading(sceneName);
        
        _loading.SetVisibility(false);
    }

    public void Initialize()
    {
        Preferences.Initialize();
    }
}