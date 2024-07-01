using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class LevelSpawner : MonoBehaviour
{
    private const int LevelsCount = int.MaxValue - 1;
    private const int LevelGap = 100;
    
    private GameObject _tempLevelGameObject;
    private int _currentLength = 50;
    private int _index;
    private int _minLevel, _maxLevel = 10;
    private LevelStorage _levelStorage;

    [Inject]
    public void Construct(LevelStorage levelStorage)
    {
        _levelStorage = levelStorage;

        for (int i = 0; i < 2; i++)
        {
            SpawnLevel();
        }
    }

    public void SpawnLevel()
    {
        switch (_index)
        {
            case > LevelsCount:
                return;
            case LevelsCount:
                _tempLevelGameObject = Instantiate(_levelStorage.GetFinalLevel);
                _tempLevelGameObject.transform.position = new Vector3(0, 0, _currentLength);
                _index++;
                return;
        }

        _minLevel = Mathf.Clamp(_index - _maxLevel, 0, int.MaxValue);
        _maxLevel = Mathf.Clamp(_minLevel + 10, 0, _levelStorage.GetPrefabCounts() - 1);

        int randoInt = Random.Range(_minLevel, _maxLevel);
        GameObject levelPrefab = _levelStorage.GetLevelPrefab(randoInt);
        _tempLevelGameObject = Instantiate(levelPrefab);

        _tempLevelGameObject.transform.position = new Vector3(0, 0, _currentLength);
        _currentLength += LevelGap;

        _levelStorage.AddLevelToList(_tempLevelGameObject);

        _index++;
    }

    public void DeleteLevel()
    {
        if (_index - 4 <= 0)
            throw new Exception($"Index out of range {_index}");
        
        _levelStorage.DeleteLevel(_index - 4);
    }
}