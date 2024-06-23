using UnityEngine;

public class MovementPrediction : MonoBehaviour
{
    [SerializeField] private LineRenderer _trajectoryPredictionLine;
    [SerializeField] private int _lineLenght = 500;

    private int _steps = 3;//2;

    private GameObject _player;
    private Vector3 _lastPos;
    private LineRenderer _trajectoryPredictionLine2;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _trajectoryPredictionLine.positionCount = _steps;
        _trajectoryPredictionLine.useWorldSpace = true;

        GameObject __trajectory2 = Instantiate(_trajectoryPredictionLine.gameObject);
        _trajectoryPredictionLine2 = __trajectory2.GetComponent<LineRenderer>();
        _trajectoryPredictionLine2.positionCount = 3;

        _lastPos = _player.transform.position;
    }
    private void FixedUpdate()
    {
        _trajectoryPredictionLine.SetPosition(0, _player.transform.position);
        _trajectoryPredictionLine.SetPosition(1, _player.transform.position + (_player.transform.position - _lastPos) * _lineLenght);
        _trajectoryPredictionLine.SetPosition(2, (_player.transform.position + (_player.transform.position - _lastPos) * _lineLenght) - _player.transform.right - _player.transform.forward);


        _trajectoryPredictionLine2.SetPosition(0, _player.transform.position);
        _trajectoryPredictionLine2.SetPosition(1, _player.transform.position + (_player.transform.position - _lastPos) * _lineLenght);
        _trajectoryPredictionLine2.SetPosition(2, (_player.transform.position + (_player.transform.position - _lastPos) * _lineLenght) + _player.transform.right - _player.transform.forward);

        _lastPos = _player.transform.position;
    }
}
/*
//_rb = _player.GetComponent<Rigidbody>();
    private Rigidbody _rb;
    private Vector3 _direction;
    private Vector3 currentPosition;
_trajectoryPredictionLine.SetPosition(0, _player.transform.position);
for (int i = 1; i < _steps; i++)
{
    _direction = (_player.transform.position - _lastPos).normalized;
    currentPosition = _player.transform.position + _direction * i * _steps; //( i / _steps);
    _lastPos = _player.transform.position;

    _trajectoryPredictionLine.SetPosition(i, currentPosition);
}
*/

//_player.transform.rotation = Quaternion.LookRotation(_player.transform.position - _lastPos);