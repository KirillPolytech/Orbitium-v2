using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public static LevelSpawner Instance {get; private set;}
    public int GetLevelsIndex { get { return _index; } }

    private int LevelsCount = int.MaxValue - 1;
    private GameObject _tempLevelGameObject;
    private int _stepBetweenLevels = 50;
    private int _index = 0;
    private int _minLevel, _maxLevel = 10;
    public void Awake()
    {
        if (!Instance) 
            Instance = this; 
        else
            Destroy(gameObject);
    }

    private void Start()
    {
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
            _tempLevelGameObject = Instantiate(LevelsStorage.Instance.GetFinalLevel);
            _tempLevelGameObject.transform.position = new Vector3(0, 0, _stepBetweenLevels);
            _index++;
            return;
        }

        _minLevel = Mathf.Clamp( _index - _maxLevel, 0, int.MaxValue);
        _maxLevel = Mathf.Clamp( _minLevel + 10, 0, LevelsStorage.Instance.GetLevelsPrefabsLength() - 1);

        _tempLevelGameObject = Instantiate(LevelsStorage.Instance.GetLevelPrefab(Random.Range(_minLevel, _maxLevel)) );

        _tempLevelGameObject.transform.position = new Vector3(0, 0, _stepBetweenLevels);
        _stepBetweenLevels += 100;

        LevelsStorage.Instance.AddLevelToList(_tempLevelGameObject);
        //Debug.Log("index: " + (__index - 2));
        //Debug.Log(__stepBetweenLevels);
        _index++;
    }

    public void DeleteLevel()
    {
        LevelsStorage.Instance.DeleteLevel(_index - 4); //__index - 4
    }
}
