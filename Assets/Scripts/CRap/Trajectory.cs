using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Trajectory : MonoBehaviour
{
    private static LineRenderer _lineRenderComponent;
    private void Start()
    {
        _lineRenderComponent = GetComponent<LineRenderer>();
    }
    public static void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[100];
        _lineRenderComponent.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
        }
        _lineRenderComponent.SetPositions(points);
    }
}
