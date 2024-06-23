using UnityEngine;

public class AvailableLevels : MonoBehaviour
{
    [SerializeField] private GameObject _selectLevelCanvas;
    private static int[] _isLevelDone = new int[35];

    public static GameObject _gameObject = null;
    private void Awake()
    {
        if (_gameObject == null)
        {
            _gameObject = gameObject;
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
/*
 public void UnlockLevel(int ind)
 {
     _isLevelDone[ind + 2] = 1;
     if (SceneManager.GetActiveScene().buildIndex == 0)
     {
         GetLevels();
         for (int i = 2; i < 35; i++)
         {
             if (_availableLevels[i] && _isLevelDone[i] == 1)
             {
                 _availableLevels[i].GetComponent<Button>().enabled = true;
                 _availableLevels[i].GetComponent<Image>().color = new Color(255, 255, 255);
             }
         }
         Debug.Log("Unlocked level " );
     }
 }
 */

/*
[SerializeField] private GameObject[] _unstaticAvailableLevels;
private void Awake()
{
    for (int i = 2; i < 30; i++)
    {
        if (_unstaticAvailableLevels[i])    
            _unstaticAvailableLevels[i].GetComponent<Image>().color = new Color(0, 0, 0);
    }
    for (int i = 0; i < 30; i++)
        _availableLevels[i] = _unstaticAvailableLevels[i];
}
public void UnlockLevel(int ind)
{
    _availableLevels[ind].GetComponent<Button>().enabled = true;
    _availableLevels[ind].GetComponent<Image>().color = new Color(255, 255, 255);
}
*/

/*
 *     private static GameObject[] _availableLevels = new GameObject[35];
private void GetLevels()
{
    _selectLevelCanvas.SetActive(true);
    for (int i = 3; i < 30; i++)
    {
        _availableLevels[i] = GameObject.Find(Convert.ToString(i));
        if (_availableLevels[i] && _isLevelDone[i] == 0)
        {
            _availableLevels[i].GetComponent<Button>().enabled = false;
            _availableLevels[i].GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }
    _selectLevelCanvas.SetActive(false);
}
*/