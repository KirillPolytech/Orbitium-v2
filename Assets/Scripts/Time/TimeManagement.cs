using UnityEngine;

public class TimeManagement : MonoBehaviour
{
    [SerializeField] private bool _isTimeFreezed = false;
    public bool IsTimeFreezed 
    { 
        get 
        { 
            return _isTimeFreezed; 
        } 
        set 
        { 
            _isTimeFreezed = value;
            if (_isTimeFreezed == true)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1f;
        } 
    }    
    private void Awake()
    {
        Time.timeScale = 1f;
        if (_isTimeFreezed)
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
