using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private string windowName;
    [SerializeField] private bool isOpened;

    public string WindowName => windowName;
    public bool IsOpened => isOpened;

    public void Open()
    {
        gameObject.SetActive(true);
        isOpened = true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        isOpened = false;
    }
}