using UnityEngine;

public class RotatingY : MonoBehaviour
{
    [SerializeField] private float r = 15f;
    [SerializeField] private float rotationSpeed = 0.02f;
    [SerializeField] private Vector3 _center = Vector3.zero;
    private float x, y;
    private float angle;
    private void FixedUpdate()
    {
        angle += rotationSpeed;
        x = Mathf.Cos(angle) * r;
        y = Mathf.Sin(angle) * r;

        transform.position = new Vector3(x, y, 0) + _center;
    }
}
