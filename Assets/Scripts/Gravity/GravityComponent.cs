using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityComponent : MonoBehaviour
{
    private const float CircleLength = Mathf.PI * 2;
    
    [SerializeField] private float GravitationConstant = 0.0000000008541557f;
    [SerializeField] private LineRenderer circleRenderer;
    [Range(4, 72)] [SerializeField] private int steps = 36;
    [Range(0, 1)] [SerializeField] private float lineWidth = 0.25f;

    private SphereCollider _sphereCollider;
    private Rigidbody _rb;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _rb = GetComponent<Rigidbody>();

        circleRenderer.useWorldSpace = true;
        circleRenderer.startWidth = lineWidth;
        circleRenderer.endWidth = lineWidth;
        DrawGravitationCircle();
    }

    private void OnTriggerStay(Collider other)
    {
        ITrajectoryChanger trajectoryChanger = other.gameObject.GetComponent<ITrajectoryChanger>();
        
        if (trajectoryChanger == null)
            return;
        
        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
        
        if (!otherRb)
            return;

        Vector3 gravityDirection = GravityCalculation.CalculateGravity(_rb, otherRb, GravitationConstant);
        
        trajectoryChanger.AddTrajectory(gravityDirection, _rb, GravitationConstant);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(TagStorage.Player))
            return;

        ITrajectoryChanger trajectoryChanger = other.GetComponent<ITrajectoryChanger>();
        
        trajectoryChanger.AddTrajectory(Vector3.zero, null, 0);
    }

    private void DrawGravitationCircle()
    {
        circleRenderer.positionCount = steps + 1;
        Vector3 parentPosition = new Vector3(
            transform.parent.transform.position.x,
            transform.parent.transform.position.y,
            transform.parent.transform.position.z);
        
        float radius = _sphereCollider.radius;
        float currentRadian;
        float x, z;
        float step = CircleLength / steps;
        int i = 0;
        for (float value = 0; value < CircleLength; value += step)
        {
            currentRadian = (float)i / steps * CircleLength;

            x = Mathf.Cos(currentRadian) * radius;
            z = Mathf.Sin(currentRadian) * radius;

            circleRenderer.SetPosition(i++, parentPosition + new Vector3(x, 0, z));
        }
    }
}