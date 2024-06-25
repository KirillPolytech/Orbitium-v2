using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(GlobalVariables.Restart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
