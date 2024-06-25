using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    private const int LevelsCount = int.MaxValue - 1;
    
    public int GetLevelsIndex => _index;

    private GameObject _tempLevelGameObject;
    private int _stepBetweenLevels = 50;
    private int _index;
    private int _minLevel, _maxLevel = 10;
    private LevelsStorage _levelsStorage;

    private void Start()
    {
        _levelsStorage = FindAnyObjectByType<LevelsStorage>();
        
        for (int i = 0; i < 2; i++)
        {
            SpawnLevel();
        }
    }

    public void SpawnLevel()
    {
        if (_index > LevelsCount)
            return;

        if (_index == LevelsCount)
        {
            _tempLevelGameObject = Instantiate(_levelsStorage.GetFinalLevel);
            _tempLevelGameObject.transform.position = new Vector3(0, 0, _stepBetweenLevels);
            _index++;
            return;
        }

        _minLevel = Mathf.Clamp( _index - _maxLevel, 0, int.MaxValue);
        _maxLevel = Mathf.Clamp( _minLevel + 10, 0, _levelsStorage.GetLevelsPrefabsLength() - 1);

        _tempLevelGameObject = Instantiate(_levelsStorage.GetLevelPrefab(Random.Range(_minLevel, _maxLevel)) );

        _tempLevelGameObject.transform.position = new Vector3(0, 0, _stepBetweenLevels);
        _stepBetweenLevels += 100;

        _levelsStorage.AddLevelToList(_tempLevelGameObject);
        //Debug.Log("index: " + (__index - 2));
        //Debug.Log(__stepBetweenLevels);
        _index++;
    }

    public void DeleteLevel()
    {
        _levelsStorage.DeleteLevel(_index - 4); //__index - 4
    }
}
