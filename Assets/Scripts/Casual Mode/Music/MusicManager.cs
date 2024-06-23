using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    private static AudioSource _music;
    public static MusicManager Instance { get; private set; }
    private void Awake()
    {
        DontDestroy();

        _music.volume = 0f;        
    }
    public static void SoundVolumeChange(float volume)
    {
        _music.volume = volume;
    }
    private void DontDestroy()
    {
        if (Instance == null)
        {
            Instance = this;
            _music = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static float GetMusicVolume()
    {
        return _music.volume;
    }
}
//SceneManager.GetActiveScene().name != "Menu")

/*
 *     //
    [SerializeField] private GameObject _scrollBarGameObject = null;
    private Scrollbar[] _scrollBars;
    private Scrollbar _scrollBar;
private void FixedUpdate()
{
    if (_scrollBarGameObject == null)
    {
        _scrollBars = Resources.FindObjectsOfTypeAll<Scrollbar>();
        foreach (var scrollbar in _scrollBars)
        {
            if (scrollbar.gameObject.name == "VolumeScrollBar")
                _scrollBarGameObject = scrollbar.gameObject;
        }
        if (_scrollBarGameObject != null)
            _scrollBar = _scrollBarGameObject.GetComponent<Scrollbar>();
        return;
    }
    SoundVolumeChange();
}
*/

//[SerializeField]private Scrollbar _scrollBar;

//_music.volume = _scrollBar.value;

//private static Scrollbar _staticScrollBar;

/*
if (!_instance)
    _instance = this;
else
    Destroy(gameObject);
DontDestroyOnLoad(gameObject);
*/