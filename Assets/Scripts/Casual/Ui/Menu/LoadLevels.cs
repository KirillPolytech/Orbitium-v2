using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(int.Parse(gameObject.name));
    }
}
