using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayEntryPoint : MonoBehaviour
{
    public void RestartScene()
    {
        GameEntryPoint.Instance.LoadScene(SceneManager.GetActiveScene().name);
    }
}
