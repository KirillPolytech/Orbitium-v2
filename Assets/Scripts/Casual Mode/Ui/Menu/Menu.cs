using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");

    }
    public void LoadSurvivalScene()
    {
        SceneManager.LoadScene("Survival");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
/*
public void LoadLevel()
{
    SceneManager.LoadScene(int.Parse(gameObject.name));
}
*/
