using System.Collections.Generic;
using UnityEngine;

public class LevelStorage : MonoBehaviour
{
    private readonly List<GameObject> _levels = new List<GameObject>();
    
    [SerializeField] private GameObject[] LevelsPrefabs;
    public static LevelStorage GetInstance { get; private set; }

    private void Awake()
    {
        GetInstance = GetComponent<LevelStorage>();
    }
    
    public void AddLevelToList(GameObject level)
    {
        _levels.Add(level);
        //Debug.Log("Levels count: " + __levels.Count);
    }
    
    public void DeleteLevel(int index)
    {
        if (index > -1 && index < _levels.Count)
        {
            GameObject temp = _levels[index];
            Debug.Log("Destroyed name: " + temp.name);
            Destroy(temp);
            return;
        }
        
        Debug.LogError("index out of range. Index: " + index + "\nLevels count: " + _levels.Count);
    }
    
    public GameObject GetLevelPrefab(int index)
    {
        return LevelsPrefabs[index];
    }
    
    public int GetLevelsPrefabsLength()
    {
        return LevelsPrefabs.Length;
    }
}
