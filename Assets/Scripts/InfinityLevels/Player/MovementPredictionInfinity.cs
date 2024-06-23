using UnityEngine;

public class MovementPredictionInfinity : MonoBehaviour
{
    [SerializeField] private LineRenderer _trajectoryPredictionLine;
    [SerializeField] private int _lineLenght = 500;

    private int _steps = 3;//3;

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
        _trajectoryPredictionLine2.transform.parent = transform;

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
private Vector3 __gravityDirection = Vector3.zero;
private Vector3 __tempPosition;
private Vector3 __tempDir;
private GameObject __planet;
private const float RAD = 0.0174533f;
private float __angle = 0;
private void AdvancedPrediction()
{
    */
/*
_trajectoryPredictionLine.SetPosition(0, _player.transform.position);

if (__planet)
    __gravityDirection = _player.transform.position - __planet.transform.position;
__tempDir = _player.GetComponent<Rigidbody>().velocity;
for (int i = 1; i < _steps; i++)
{
    __tempPosition = _player.transform.position + (__tempDir + __gravityDirection); /// (_steps - i);

    __angle = (-90 + Vector3.Angle(__tempPosition, __gravityDirection)) * RAD;

    if (__gravityDirection != Vector3.zero)
    {
        __gravityDirection = __tempPosition - __planet.transform.position;
        __tempDir = new Vector3(
            __tempDir.x * Mathf.Cos(__angle) - __tempDir.z * Mathf.Sin(__angle), 0,
            __tempDir.x * Mathf.Sin(__angle) + __tempDir.z * Mathf.Cos(__angle)
            );
        Debug.Log(-90 + " + " + __angle / RAD);
        //Debug.DrawRay(_player.transform.position, __tempPosition, Color.green);
        Debug.DrawRay(__tempPosition, __gravityDirection, Color.green);
    }

    _trajectoryPredictionLine.SetPosition(i, __tempPosition); // __temp
}
    Debug.DrawRay(_player.transform.position, __gravityDirection, Color.green);
}
public void SetGravityDirection(Vector3 dir, GameObject planet)
{
    //__gravityDirection = dir;
    __planet = planet;
}
}
}
                */
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

//_trajectoryPredictionLine.SetPosition(1, _player.transform.position + _player.transform.forward);
//+ __gravityDirection); /// (i + 1) );

//__tempDir = CalculatePerpendicularVector((__planet.transform.position - __temp) / 10);
/*
private Vector3 CalculatePerpendicularVector(Vector3 vector)
{
    if (vector.x > 0 && vector.z > 0)
    {
        return new Vector3( 1 / vector.x, -1 / vector.z).normalized * vector.magnitude;
    }
    if (vector.x < 0 && vector.z < 0)
    {
        return new Vector3( -1 / vector.x, 1 / vector.z ) * vector.magnitude;
    }
    if (vector.x > 0 && vector.z < 0)
    {
        return new Vector3( 1 / vector.x, 1 / -vector.z ) * vector.magnitude;
    }
    if (vector.x < 0 && vector.z > 0)
    {
        return new Vector3( 1 / -vector.x, 1 / vector.z) * vector.magnitude;
    }
    return Vector3.zero;
}
*/
