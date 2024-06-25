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

        GameObject trajectoryArrow = Instantiate(trajectoryPredictionLine.gameObject);
        _trajectoryPredictionLine2 = trajectoryArrow.GetComponent<LineRenderer>();
        _trajectoryPredictionLine2.positionCount = 3;
        _trajectoryPredictionLine2.transform.parent = transform;

        _lastPos = transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 one = transform.position + (transform.position - _lastPos) * lineLenght;
        Vector3 two = transform.position + (transform.position - _lastPos) * lineLenght - transform.right - transform.forward;
        Vector3 three = transform.position + (transform.position - _lastPos) * lineLenght + transform.right - transform.forward;
        
        trajectoryPredictionLine.SetPosition(0, transform.position);
        trajectoryPredictionLine.SetPosition(1, one);
        trajectoryPredictionLine.SetPosition(2, two);

        _trajectoryPredictionLine2.SetPosition(0, transform.position);
        _trajectoryPredictionLine2.SetPosition(1, one);
        _trajectoryPredictionLine2.SetPosition(2, three);

        _lastPos = transform.position;
    }
}