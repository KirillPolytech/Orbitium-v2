using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int AmountEnemies = 500;

    private GameObject _spawnedEnemy;
    private void Awake()
    {
        for (int i = 0; i < AmountEnemies; i++)
        {
            _spawnedEnemy = Instantiate(EnemyPrefab);

            _spawnedEnemy.name = "Enemy " + i;

            _spawnedEnemy.transform.position = new Vector3(Random.Range(-490f, 490f), 0, Random.Range(-490f, 490f));
        }
    }
}
/*
for (int j = 0; j < AmountEnemies; j++)
{
    _spawnPosition = new(Random.Range(-490f, 490f), 0, Random.Range(-490f, 490f));

    _spawnedEnemy.transform.position = _spawnPosition;
}
           //_spawnedEnemy.transform.position = _spawnPosition;
*/

/*
 *     private float _minDistance = float.MaxValue;
    GameObject _nearestGameObject = null;
    private float _distance;
    private GameObject[] _allEnemies;

            _allEnemies[i] = _spawnedEnemy;

public GameObject NearestEnemyToObject(in GameObject CurrentObject, int Radius)
{
    for (int i = 0; i < AmountEnemies; i++)
    {
        if (_allEnemies[i] != null && _allEnemies[i] != CurrentObject)
        {
            _distance = (_allEnemies[i].transform.position - CurrentObject.transform.position).magnitude;
            if (_distance < _minDistance)
            {
                _minDistance = _distance;
                _nearestGameObject = _allEnemies[i];
            }
        }
    }
    return _nearestGameObject;
}

*/