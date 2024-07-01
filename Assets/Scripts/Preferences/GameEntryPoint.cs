using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    public static GameEntryPoint Instance;

    private AsyncOperation _operation;
    private LoadingUI _loadingUI;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void AutoStartGame()
    {
        Instance = new GameEntryPoint();
    }

    private GameEntryPoint()
    {
        _loadingUI = Resources.Load<LoadingUI>("LoadingPrefab");
        _loadingUI = Object.Instantiate(_loadingUI);
        Object.DontDestroyOnLoad(_loadingUI);

#if !UNITY_EDITOR
        LoadScene(SceneNamesStorage.MenuSceneName);
#endif
    }

    public void LoadScene(string sceneName)
    {
        _loadingUI.SetVisibility(true);

        SceneManager.LoadScene(SceneNamesStorage.BootSceneName);

        _loadingUI.StartLoading(sceneName);

        _loadingUI.SetVisibility(false);
    }

    public void Initialize()
    {
        Preferences.Initialize();
    }
}