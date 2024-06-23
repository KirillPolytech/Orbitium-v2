using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    private MainPlayer _player;
    private UIManager _ui;
    private ForceOnDrag _onDrag;
    private void Awake()
    {
        Preferences.Initialize();

        _player = FindObjectOfType<MainPlayer>();
        _ui = FindObjectOfType<UIManager>();
        _onDrag = FindObjectOfType<ForceOnDrag>();

        _player.Initialize();
        _ui.Initialize();
        _onDrag.Initialize();
    }
}
