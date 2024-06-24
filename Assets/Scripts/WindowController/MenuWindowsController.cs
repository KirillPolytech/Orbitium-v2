using System.Linq;
using UnityEngine;

public class MenuWindowsController : WindowsController
{
    public string Current { get; private set; } = "Main";
    public string Main { get; private set; } = "Main";
    public string SelectLevels { get; private set; } = "SelectLevels";
    public string Settings { get; private set; } = "Settings";
    public string Exit { get; private set; } = "Exit";
    
    private void Start()
    {
        foreach (Window window in windows)
            window.Close();

        OpenWindow(Current);
    }

    public void CloseCurrent()
    {
        if (Current == null)
            return;

        Window window = windows.Single(x => x.WindowName == Current);
        window.Close();

        Current = null;
    }

    public void OpenWindow(string windowName)
    {
        if (windowName == null)
        {
            CloseCurrent();
            return;
        }

        Window window = windows.Single(x => x.WindowName == windowName);

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
}