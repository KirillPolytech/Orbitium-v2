using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private string MenuName;
    [SerializeField] private bool IsOpened;

    public string GetMenuName => MenuName;
    public bool GetIsOpened => IsOpened;

    private Canvas _canvas;
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();

        if (_canvas.enabled == true)
        {
            IsOpened = true;
        }
    }

    public void Open()
    {
        _canvas.enabled = true;
        IsOpened = true;
    }

    public void Close()
    {
        _canvas.enabled = false;
        IsOpened = false;
    }
}
