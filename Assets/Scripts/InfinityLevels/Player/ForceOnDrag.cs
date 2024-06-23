using UnityEngine;

[RequireComponent(typeof(MovementDirectionLine))]
public class ForceOnDrag : MonoBehaviour
{
    [Range(0,1f) ][SerializeField] private float Force = 1f;

    private RaycastHit _spotHit;
    private Ray _cameraRay;
    private Vector3 _direction;
    private const float _maxRayDistance = 500f;
    private bool _isHoldingLeftButtonDown = false;
    private Vector2 _mousePosition;
    private MainPlayer _player;
    private GameObject _playerGameObject;
    private Rigidbody _playerRigidBody;
    private Vector3 _gravityDirection = Vector3.zero;
    private Vector3 _lastPosition;
    private MovementDirectionLine _line;
    public void Initialize()
    {
        _player = MainPlayer.Instance.GetComponent<MainPlayer>();
        _playerGameObject = MainPlayer.Instance.gameObject;
        _playerRigidBody = MainPlayer.Instance.GetComponent<Rigidbody>();
        _lastPosition = _player.transform.position;

        _player.EventAtDeath += () => Destroy(this);

        _line = GetComponent<MovementDirectionLine>();
    }
    private void Update()
    {
        _isHoldingLeftButtonDown = Input.GetButton(GlobalVariables.LeftMouseButton);

        _mousePosition = Input.mousePosition;
    }
    private void FixedUpdate()
    {
        if (_player.transform.position - _lastPosition != Vector3.zero)
        {
            _player.RotatePlayer(_player.transform.position - _lastPosition);
        }

        _lastPosition = _player.transform.position;

        DragForce();
    }
    public void SetGravityDirection(Vector3 GravityDirection)
    {
        _gravityDirection = GravityDirection;
    }
    private void DragForce()
    {
        _cameraRay = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(_cameraRay, out _spotHit, _maxRayDistance))
        {
            if (!_spotHit.collider.CompareTag("Player") && _isHoldingLeftButtonDown && _player.GetStamina > 0f)
            {
                _direction = _spotHit.point - _playerGameObject.transform.position;
                _direction.y = 0;

                _playerRigidBody.velocity = _direction * Force + _gravityDirection;

                _player.WasteStamina();

                _line.SetLinePosition(_spotHit, _playerGameObject);
            }

            if (_player.GetStamina <= 0f)
            {
                _line.ResetLinePosition();
            }
        }
        if (_isHoldingLeftButtonDown == false)
        {
            _line.ResetLinePosition();
        }

        Debug.DrawLine(_cameraRay.origin, _spotHit.point, Color.red);
        Debug.DrawLine(_playerGameObject.transform.position, _spotHit.point, Color.blue);
    }

}
/*
1 - Проверить, держим ли мы кнопку.
2 - Проверить, убрали ли мы мышку с игрока.
3 - Создать вектор в направлении точки удара с поверхностью.
4 - Добавить силу к игроку в направлении этого вектора.
*/

// IsHittedPlayer = (Physics.Raycast(_cameraRay, out _playerHit, _maxRayDistance) && _playerHit.collider.CompareTag("PlayerInfinity"));

// Сделал то же самое что и addforce
//__playerGameObject.GetComponent<Rigidbody>().velocity = _direction * Force + _gravityDirection + __playerGameObject.GetComponent<Rigidbody>().velocity;


/*
void DragForce()
    {
        _cameraRay = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(_cameraRay, out _spotHit, _maxRayDistance))
        {
            if (!_spotHit.collider.CompareTag("PlayerInfinity") && _isHoldingLeftButtonDown && __player.GetStamina > 0f)
            {
                _direction = _spotHit.point - __playerGameObject.transform.position;
                _direction = new(_direction.x, 0, _direction.z);

                __playerGameObject.GetComponent<Rigidbody>().AddForce(_direction * Force, ForceMode.Impulse);

                __player.WasteStamina();

                SetLinePosition();
            }
            if (__player.GetStamina <= 0f)
                SetLinePositionToZero();
        }
        if (!_isHoldingLeftButtonDown)
        {
            SetLinePositionToZero();
        }

        Debug.DrawLine(_cameraRay.origin, _spotHit.point, Color.red);
        Debug.DrawLine(__playerGameObject.transform.position, _spotHit.point, Color.blue);
    }
*/

/*
private void OnTriggerStay(Collider other)
{   
    if (other.gameObject.CompareTag("StaticPlanet"))
    {
        Gravitation _otherGravityComponent = other.GetComponentInChildren(typeof(Gravitation)) as Gravitation;

        _gravityDirection = _otherGravityComponent.GravitationJobVector3(other.gameObject, gameObject);
        Debug.Log("_gravityDirection");
    }
}
*/

//__playerGameObject.GetComponent<Rigidbody>().AddForce(_direction * Force, ForceMode.Impulse);
