using UnityEngine;

public class RotationAroundObject : MonoBehaviour
{
    [SerializeField] private float r = 15f;
    [SerializeField] private float rotationSpeed = 0.02f;
    [SerializeField] private GameObject _gameObject;
    
    private float _x, _z;
    private float _angle;
    
    private void FixedUpdate()
    {
        _angle += rotationSpeed;
        _x = Mathf.Cos(_angle) * r;
        _z = Mathf.Sin(_angle) * r;

        transform.position = new Vector3(_x, 0, _z) + _gameObject.transform.position;
    }
}
