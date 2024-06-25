using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private const int PointsCout = 360;
    private const float LineWidth = 0.1f;
    private float _deltaTime;

    [SerializeField] private Material lineMaterial;
    
    private LineRenderer _lineRenderComponent;

    private void Start()
    {
        _deltaTime = Time.fixedDeltaTime;
        
        GameObject lineRenderComponent = new GameObject();
        _lineRenderComponent = lineRenderComponent.AddComponent<LineRenderer>();

        _lineRenderComponent.positionCount = PointsCout;
        _lineRenderComponent.useWorldSpace = true;
        _lineRenderComponent.startWidth = LineWidth;
        _lineRenderComponent.endWidth = LineWidth;
        _lineRenderComponent.material = lineMaterial;
    }

    private Vector3[] CalculateTrajetory(Rigidbody current, Rigidbody other, Vector3 currentPos, Vector3 otherPos,
        float gravityConst)
    {
        Vector3[] points = new Vector3[PointsCout];

        Vector3 tempPos = currentPos;
        Vector3 tempVelocity = current.velocity;
        for (int i = 0; i < PointsCout; i++)
        {
            Vector3 tempPos2 = tempPos;
            tempPos += (tempVelocity + GravityCalculation.CalculateGravity(current, other, tempPos, otherPos, gravityConst)) 
                       * _deltaTime;
            tempVelocity = (tempPos - tempPos2) / _deltaTime;
            points[i] = tempPos;
        }

        return points;
    }

    public void ShowTrajectory(Rigidbody current, Rigidbody other, Vector3 currentPos, Vector3 otherPos,
        float gravityConst)
    {
        _lineRenderComponent.SetPositions(CalculateTrajetory(current, other, currentPos, otherPos, gravityConst));
    }
}