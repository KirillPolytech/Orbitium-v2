using UnityEngine;

public class TimeManagement : MonoBehaviour
{
    [SerializeField] private bool isTimeFreezed;

    private void Awake()
    {
        Time.timeScale = 1f;
        if (isTimeFreezed)
            Time.timeScale = 0f;
    }
    
    public static void FreezeeTime()
    {
        Time.timeScale = 0f;
    }
    
    public static void UnFreezeeTime()
    {
        Time.timeScale = 1f;
    }
}
