using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    const int SCORELENGTH = 35;
    private static int[] __scores = new int[SCORELENGTH];
    private static int index = -1;
    private void Awake()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    public static void AddScore(int value)
    {
        if (index > -1 && index < SCORELENGTH)
        {
            __scores[index] += value;
        }
        else
        {
            //Debug.Log("ind out of range");
        }
    }
    public static int GetScore(int ind)
    {
        if (ind > -1 && ind < SCORELENGTH)
        {
            return __scores[ind];
        }
        else
        {
            //Debug.Log("ind out of range");
            return -1;
        }
    }
}


            /*
        public static void AddScore(int value)
        if (_scores.Count < index && index != -1)
            _scores.Add(value);
        else if (value < _scores[index])
            _scores[index] = value;
    }
    public static int GetScore(int index)
    {
        if (_scores.Count < index - 2) // 0 
            return 0;
        else
            return _scores[index];
    }
        */