using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField] private float GravitationConstant = 0.0000000008541557f;
    [SerializeField] private LineRenderer circleRenderer;
    [Range(36, 72)] [SerializeField] private int steps = 36;

    public float GravityConstant => GravitationConstant;

    private Rigidbody _rb;
    private SphereCollider _sphereCollider;

    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _rb = transform.parent.GetComponent<Rigidbody>();

        circleRenderer.useWorldSpace = true;
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
        if (!otherRb)
            return;

        otherRb.AddForce(GravityCalculation.CalculateGravity(_rb, otherRb, GravitationConstant), ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        DrawGravitationCircle();
    }

    private void DrawGravitationCircle()
    {
        circleRenderer.positionCount = steps;
        Vector3 parentPosition = new Vector3(transform.parent.transform.position.x,
            transform.parent.transform.position.y,
            transform.parent.transform.position.z);

        float x, z;
        float radius = _sphereCollider.radius;
        float currentRadian;
        for (int i = 0; i < steps - 1; i++)
        {
            currentRadian = (float)i / steps * 2 * Mathf.PI;

            x = Mathf.Cos(currentRadian) * radius;
            z = Mathf.Sin(currentRadian) * radius;

            circleRenderer.SetPosition(i, parentPosition + new Vector3(x, 0, z));
        }

        x = Mathf.Cos(Mathf.PI * 2) * radius;
        z = Mathf.Sin(Mathf.PI * 2) * radius;
        circleRenderer.SetPosition(steps - 1, parentPosition + new Vector3(x, 0, z));
    }
}