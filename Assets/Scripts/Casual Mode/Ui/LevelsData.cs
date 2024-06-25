using UnityEngine;

public class LevelsData : MonoBehaviour
{
    private static Data[] data = new Data[35];
    public static GameObject _gameObject;
    
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
    
    public static void SetLevelData(int score, float time, int ind)
    {
        data[ind].Score = score;
        data[ind].Time = time;
    }
    
    public static Data GetLevelData(int ind)
    {
        return data[ind];
    }
}
public struct Data
{
    public int Score;
    public float Time;
}
