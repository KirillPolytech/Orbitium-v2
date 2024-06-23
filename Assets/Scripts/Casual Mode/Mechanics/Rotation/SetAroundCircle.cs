using UnityEngine;

public class SetAroundCircle : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _objectsCount = 36;
    [SerializeField] private float radius = 10f;
    [SerializeField] private Vector3 _center = Vector3.zero;
    //[SerializeField] private float rotatingSpeed = 0.01f;

    private GameObject[] _instanceGameObject;
    private float currentRadian;
    private float x, z;
    private void Awake()
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
        for (int i = 0; i < _objectsCount; i++)
        {
            currentRadian = (float)i / _objectsCount * 2 * Mathf.PI;

            x = Mathf.Cos(currentRadian) * radius;
            z = Mathf.Sin(currentRadian) * radius;

            _instanceGameObject[i].transform.position = new Vector3(x, 0, z) + _center;
        }
    }
}
