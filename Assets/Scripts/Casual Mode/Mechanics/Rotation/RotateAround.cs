using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private float r = 15f;
    [SerializeField] private float rotationSpeed = 0.02f;
    [SerializeField] private Vector3 _center = Vector3.zero;

    [SerializeField] private bool X, Y, Z;

    private float x, y, z;
    private float angle;
    private void FixedUpdate()
    {
        angle += rotationSpeed;
        if (X)
            x = Mathf.Cos(angle) * r;
        if (Y)
            y = Mathf.Sin(angle) * r;
        if (Z)
            z = Mathf.Sin(angle) * r;

        transform.position = new Vector3(x, y, z) + _center;
    }
}
