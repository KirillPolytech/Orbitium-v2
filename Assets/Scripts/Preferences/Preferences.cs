using UnityEngine;

public class Preferences
{
    public static void Initialize()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        Cursor.lockState = CursorLockMode.Confined;
    }
}