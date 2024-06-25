using System.Linq;
using UnityEngine;

public abstract class WindowsController : MonoBehaviour
{
    [SerializeField] protected Window[] windows;
    
    public string Current { get; private set; } = "Main";
    
    private void Start()
    {
        foreach (Window window in windows)
            window.Close();

        OpenWindow(Current);
    }
    
    public void OpenWindow(string windowName)
    {
        if (windowName == null)
        {
            CloseCurrent();
            return;
        }

        Window window = windows.Single(x => x.WindowName == windowName);

        if (!window)
        {
            Debug.LogWarning("Unknown window");
            return;
        }

        Current = window.WindowName;

        foreach (Window m in windows.Where(x => x.IsOpened))
            m.Close();

        window.Open();
        Debug.Log($"Window: Open {window.WindowName}");
    }

    public void OpenWindow(Window window)
    {
        foreach (Window m in windows.Where(x => x.IsOpened))
            m.Close();
        
        window.Open();
        
        Debug.Log($"Window: Open {window.WindowName}");
    }

    public void CloseCurrent()
    {
        if (Current == null)
            return;

        Window window = windows.Single(x => x.WindowName == Current);
        window.Close();

        Current = null;
    }
}
