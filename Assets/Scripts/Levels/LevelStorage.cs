using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class LevelStorage : MonoBehaviour
{
    [SerializeField] private GameObject FirstLevel;
    [SerializeField] private GameObject FinalLevel;
    [SerializeField] private List<GameObject> LevelsPrefabs = new List<GameObject>();

    public GameObject GetFinalLevel => FinalLevel;

    private readonly List<GameObject> _levels = new List<GameObject>();
    private int _passedLevels;
    private InGameUI _gameUI;

    [Inject]
    public void Construct(InGameUI inGameUI)
    {
        _gameUI = inGameUI;
        _levels.Add(FirstLevel);
    }

    public void Initialize(GameObject[] levelPrefabs)
    {
        if (levelPrefabs.Length == 0)
            throw new Exception("Empty prefabs");

        foreach (var obj in levelPrefabs)
        {
            obj.name = TextParser.ParseTextToInt(obj.name);

            LevelsPrefabs.Add(obj);
        }

        LevelsPrefabs = LevelsPrefabs.OrderByDescending(x => int.Parse(x.name)).ToList();
        LevelsPrefabs.Reverse();
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
            if (!_levels[index])
                throw new Exception("Level doesn't exist");

            GameObject temp = _levels[index];
            Debug.Log($"Destroyed level: {temp.name} index: {index}");
            Destroy(temp);
            
            return;
        }
        
        throw new Exception($"index out of range. Index: {index} Levels count: {_levels.Count}");
    }

    public GameObject GetLevelPrefab(int index)
    {
        if (index >= LevelsPrefabs.Count || index < 0)
            throw new Exception($"Index out of range {index}");

        return LevelsPrefabs[Mathf.Clamp(index, 0, GetPrefabCounts() - 1)];
    }

    public int GetPrefabCounts()
    {
        return LevelsPrefabs.Count;
    }

    public void IncreasePassedLevels()
    {
        _gameUI.UpdatePassedLevelsCounter(++_passedLevels);
    }
}