using UnityEngine;

public class SetArounCircleY : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _objectsCount = 12;
    [SerializeField] private float radius = 10f;
    [SerializeField] private Vector3 _center;
    [SerializeField] private float rotatingSpeed = 0.005f;
    private float currentSpeed = 0;

    private GameObject[] _instanceGameObject;
    private float currentRadian;
    private float x, y;
    private void Start()
    {
        _instanceGameObject = new GameObject[_objectsCount];
        for (int i = 0; i < _objectsCount; i++)
        {
            _instanceGameObject[i] = Instantiate(_prefab, new Vector3(50, 50, 50), Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        SetCircle();
    }
    private void SetCircle()
    {
        currentSpeed += rotatingSpeed;
        for (int i = 0; i < _objectsCount; i++)
        {
            currentRadian = (float)i / _objectsCount * 2 * Mathf.PI + currentSpeed;

            x = Mathf.Cos(currentRadian) * radius;
            y = Mathf.Sin(currentRadian) * radius;

            _instanceGameObject[i].transform.position = new Vector3(x, y, 0) + _center;
        }
    }
}
