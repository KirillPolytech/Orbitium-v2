using UnityEngine;
using UnityEngine.UI;

public class ScrollBarManager : MonoBehaviour
{
    private static Scrollbar _scrollBar;
    private void Start()
    {
        if (_scrollBar == null)
            _scrollBar = GetCertainScrollBar("VolumeScrollBar");
        _scrollBar.value = MusicManager.GetMusicVolume();
    }
    private void FixedUpdate()
    {
        MusicManager.SoundVolumeChange(_scrollBar.value);
    }
    public static Scrollbar GetCertainScrollBar(string ScrollBarName)
    {
        foreach (var scrollBar in Resources.FindObjectsOfTypeAll<Scrollbar>())
        {
            if (scrollBar.name == ScrollBarName)
                return scrollBar;
        }
        return null;
    }
}

/*
 * if (_staticScrollBar == null) 
        {
            foreach (var scrollBar in Resources.FindObjectsOfTypeAll<Scrollbar>())
            {
                if (scrollBar.name == "VolumeScrollBar")
                    _staticScrollBar = scrollBar;
            }
        }
*/

//_musicPlayer = GameObject.Find("Music");
//if (_musicPlayer != null)
//_musicManager = _musicPlayer.GetComponent<MusicManager>();

/* 
if (_musicPlayer != null)
{
    _musicManager.SoundVolumeChange(_scrollBar.value);
}
*/
//private static GameObject _musicPlayer;
//private static MusicManager _musicManager;

//[SerializeField] private GameObject _musicPlayerUnStatic;
//[SerializeField] private MusicManager _musicManagerUnStatic;