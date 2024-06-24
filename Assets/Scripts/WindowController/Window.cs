using UnityEngine;

public class Window : MonoBehaviour
{
    public string windowName;
    public bool IsOpened { get; private set; }

    public void Open()
    {
        gameObject.SetActive(true);
        IsOpened = true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        IsOpened = false;
    }
}