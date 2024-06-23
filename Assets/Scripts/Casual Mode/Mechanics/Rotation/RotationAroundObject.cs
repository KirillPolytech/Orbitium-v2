using UnityEngine;

public class RotationAroundObject : MonoBehaviour
{
    [SerializeField] private float r = 15f;
    [SerializeField] private float rotationSpeed = 0.02f;
    [SerializeField] private GameObject _gameObject;
    private float x, z;
    private float angle;
    private void FixedUpdate()
    {
        angle += rotationSpeed;
        x = Mathf.Cos(angle) * r;
        z = Mathf.Sin(angle) * r;

        transform.position = new Vector3(x, 0, z) + _gameObject.transform.position;
    }
}
