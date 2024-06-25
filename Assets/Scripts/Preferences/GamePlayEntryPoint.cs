using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        GameEntryPoint.Instance.Initialize();
    }

    public void RestartScene()
    {
        GameEntryPoint.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }
}