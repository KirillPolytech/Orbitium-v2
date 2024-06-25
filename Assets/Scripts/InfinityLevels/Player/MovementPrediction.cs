using UnityEngine;

public class MovementPrediction : MonoBehaviour
{
    private const int Steps = 3;
    
    [SerializeField] private LineRenderer trajectoryPredictionLine;
    [Range(0,100)][SerializeField] private int lineLenght = 50;
    
    private Vector3 _lastPos;
    private LineRenderer _trajectoryPredictionLine2;
    
    private void Start()
    {
        trajectoryPredictionLine.positionCount = Steps;
        trajectoryPredictionLine.useWorldSpace = true;

        GameObject trajectory2 = Instantiate(trajectoryPredictionLine.gameObject);
        _trajectoryPredictionLine2 = trajectory2.GetComponent<LineRenderer>();
        _trajectoryPredictionLine2.positionCount = 3;
        _trajectoryPredictionLine2.transform.parent = transform;

        _lastPos = transform.position;
    }
    private void FixedUpdate()
    {
        trajectoryPredictionLine.SetPosition(0, transform.position);
        trajectoryPredictionLine.SetPosition(1, transform.position + (transform.position - _lastPos) * lineLenght);
        trajectoryPredictionLine.SetPosition(2, (transform.position + (transform.position - _lastPos) * lineLenght) - transform.right - transform.forward);

        _trajectoryPredictionLine2.SetPosition(0, transform.position);
        _trajectoryPredictionLine2.SetPosition(1, transform.position + (transform.position - _lastPos) * lineLenght);
        _trajectoryPredictionLine2.SetPosition(2, transform.position + (transform.position - _lastPos) * lineLenght + transform.right - transform.forward);

        _lastPos = transform.position;
    }
}