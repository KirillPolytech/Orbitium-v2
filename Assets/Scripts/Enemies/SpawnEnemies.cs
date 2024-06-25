using UnityEngine;
public class SpawnEnemies : MonoBehaviour
{
    private float _timer;
    public GameObject Enemies;
    Vector3 _positionRight, PositionLeft;

    private void FixedUpdate()
    {
        if (_timer == 150)
        {
            _timer = 0;
            _positionRight = new(Camera.main.transform.position.x + Random.Range(50f, 100f), 0 , Camera.main.transform.position.z + Random.Range(50f, 100f) );
            PositionLeft = new(Camera.main.transform.position.x - Random.Range(50f, 100f), 0, Camera.main.transform.position.z - Random.Range(50f, 100f));
            if (Random.Range(-1f,1f) >= 0)
            {
                Instantiate(Enemies, _positionRight, Quaternion.identity);
            }else
            {
                Instantiate(Enemies, PositionLeft, Quaternion.identity);
            }
        }
        _timer++;
    }
}
