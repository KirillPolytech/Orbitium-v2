using UnityEngine;

public class AvailableLevels : MonoBehaviour
{
    [SerializeField] private GameObject _selectLevelCanvas;
    private static int[] _isLevelDone = new int[35];

    public static GameObject Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
    }

    public void UnlockLevel(int ind)
    {
        _isLevelDone[ind] = 1;
    }

    public int[] GetLevelConditions()
    {
        return _isLevelDone;
    }
}