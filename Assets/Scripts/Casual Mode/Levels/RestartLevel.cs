using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
