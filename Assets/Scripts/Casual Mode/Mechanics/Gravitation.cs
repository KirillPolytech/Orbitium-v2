using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField] private float GravitationConstant = 0.0000000008541557f;

    [SerializeField] private LineRenderer circleRenderer;
    [Range(36, 72)] [SerializeField] private int steps = 36;

    private float _radius;
    private float _currentRadian;
    private float _x, _z;
    private float _distanceToPlanet, _sunMass, _otherMass;
    private float _gravity;
    private Vector3 _parentPosition;
    private Rigidbody _rb;

    private void Start()
    {
        circleRenderer.useWorldSpace = true;
        _radius = GetComponent<SphereCollider>().radius;
        _rb = transform.parent.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        DrawCircle();
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (!rb)
            return;

        rb.AddForce(GravityCalculation.CalculateGravityForce(rb, _rb, GravitationConstant), ForceMode.Impulse);
    }

    private void DrawCircle()
    {
        circleRenderer.positionCount = steps;
        _parentPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y,
            transform.parent.transform.position.z);

        for (int i = 0; i < steps - 1; i++)
        {
            _currentRadian = (float)i / steps * 2 * Mathf.PI;

            _x = Mathf.Cos(_currentRadian) * _radius;
            _z = Mathf.Sin(_currentRadian) * _radius;

            circleRenderer.SetPosition(i, _parentPosition + new Vector3(_x, 0, _z));
        }

        _x = Mathf.Cos(Mathf.PI * 2) * _radius;
        _z = Mathf.Sin(Mathf.PI * 2) * _radius;
        circleRenderer.SetPosition(steps - 1, _parentPosition + new Vector3(_x, 0, _z));
    }
}