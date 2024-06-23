using UnityEngine;

public class Preferences : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
//Time.timeScale = 1;