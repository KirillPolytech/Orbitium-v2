using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        GameEntryPoint.Initialize();
    }

    public void RestartScene()
    {
        GameEntryPoint.LoadScene(SceneManager.GetActiveScene().name);
    }
}