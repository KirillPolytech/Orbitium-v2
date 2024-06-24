using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsStorage : MonoBehaviour
{
    private readonly char[] _integers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

    [SerializeField] private GameObject FirstLevel;
    [SerializeField] private GameObject FinalLevel;
    [SerializeField] private List<GameObject> LevelsPrefabs = new List<GameObject>();

    public static LevelsStorage Instance { get; private set; }
    public GameObject GetFinalLevel => FinalLevel;

    private readonly List<GameObject> _levels = new List<GameObject>();
    private int _passedLevels;
    
    public void Awake()
    {
        if (Instance == false)
            Instance = this;
        else 
            Destroy(gameObject);

        _levels.Add(FirstLevel);

        GameObject[] levelsTemp = Resources.LoadAll<GameObject>("Levels");
        GameObject[] levelsTempCopy = new GameObject[levelsTemp.Length];

        levelsTemp.CopyTo(levelsTempCopy, 0);

        for (int i = 0; i < levelsTemp.Length; i++)
        {
            levelsTempCopy[i].name = ParseTextToInt(levelsTemp[i].name);

            LevelsPrefabs.Add(levelsTempCopy[i]) ;
        }
        LevelsPrefabs = LevelsPrefabs.OrderByDescending(x => int.Parse(x.name) ).ToList();
        LevelsPrefabs.Reverse();
    }

    public void AddLevelToList(GameObject level)
    {
        _levels.Add( level);
        //Debug.Log("Levels count: " + __levels.Count);
    }

    public void DeleteLevel(int index)
    {
        if (index > -1 && index < _levels.Count)
        {
            if (!_levels[index])
            {
                Debug.Log("Level doesnt exist");
                return;
            }
            GameObject __temp = _levels[index];
            Debug.Log("Destroyed name: " + __temp.name + " index: " + index);
            Destroy(__temp);
        }
        else
        {
            Debug.Log("index out of range. Index: " + index + "\nLevels count: " + _levels.Count);
        }
    }

    public GameObject GetLevelPrefab(int index)
    {
        return LevelsPrefabs[ Mathf.Clamp(index,0, GetLevelsPrefabsLength() - 1 )];
    }

    public int GetLevelsPrefabsLength()
    {
        return LevelsPrefabs.Count;
    }

    private string ParseTextToInt(string text)
    {
        string output = "";
        foreach (var t in text)
        {
            foreach (var t1 in _integers)
            {
                if (t == t1)
                {
                    output += t1;                   
                }
            }
        }
        return output;
    }

    public void IncreasePassedLevels()
    {
        _passedLevels++;

        //UIManager.Instance.UpdatePassedLevelsCounter(_passedLevels);
    }
}