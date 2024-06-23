using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");

    }
    public void LoadRunnerScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}