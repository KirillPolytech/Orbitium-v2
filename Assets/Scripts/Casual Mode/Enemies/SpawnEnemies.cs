using UnityEngine;
public class SpawnEnemies : MonoBehaviour
{
    public GameObject Enemies;
    
    private float _timer;
    private Vector3 _positionRight, _positionLeft;

    private void FixedUpdate()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_timer > 150)
        {
            _timer = 0;
            _positionRight = new Vector3(Camera.main.transform.position.x + Random.Range(50f, 100f), 0 , Camera.main.transform.position.z + Random.Range(50f, 100f) );
            _positionLeft = new Vector3(Camera.main.transform.position.x - Random.Range(50f, 100f), 0, Camera.main.transform.position.z - Random.Range(50f, 100f));
            Instantiate(Enemies, Random.Range(-1f, 1f) >= 0 ? _positionRight : _positionLeft, Quaternion.identity);
        }
        _timer++;
    }
}
