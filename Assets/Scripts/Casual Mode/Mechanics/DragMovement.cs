using UnityEngine;

public class DragMovement : MonoBehaviour
{
    private const float MaxRayDistance = 500f;
    
    [Range(0,10)][SerializeField] private float Force = 1f;
    [SerializeField] private LineRenderer Line;

    private RaycastHit _spotHit;
    private Ray _cameraRay;
    private Vector3 _direction;
    private Vector3 _hitCoordinates;
    private bool _isHoldingLeftButtonDown;
    private Vector2 _mousePosition;
    private Vector3 _gravityDirection;
    private Vector3 _lastPosition;
    private Player _player;
    private Rigidbody _rb;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _rb = GetComponent<Rigidbody>();
        
        _lastPosition = transform.position;

        Line.useWorldSpace = true;
        Line.startWidth = 1f;
        Line.endWidth = 0.3f;
    }
    
    private void Update()
    {
        _isHoldingLeftButtonDown = Input.GetButton("Fire1");
        _mousePosition = Input.mousePosition;
    }
    
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _lastPosition);
        _lastPosition = transform.position;
        DragForce();
    }
    
    public void SetGravityDirection(Vector3 gravityDirection)
    {
        _gravityDirection = gravityDirection;
    }

    private void DragForce()
    {
        _cameraRay = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(_cameraRay, out _spotHit, MaxRayDistance))
        {
            if (!_spotHit.collider.CompareTag("Player") && _isHoldingLeftButtonDown && _player.Stamina > 0f)
            {
                _direction = _spotHit.point - gameObject.transform.position;
                _direction = new Vector3(_direction.x, 0, _direction.z);

                _rb.velocity = _direction * Force + _gravityDirection;

                _player.WasteStamina();

                SetLinePosition();
            }
            
            if (_player.Stamina <= 0f)
                SetLinePositionToZero();
        }
        
        if (!_isHoldingLeftButtonDown)
        {
            SetLinePositionToZero();
        }

        Debug.DrawLine(_cameraRay.origin, _spotHit.point, Color.red);
        Debug.DrawLine(transform.position, _spotHit.point, Color.blue);
    }

    private void SetLinePosition()
    {
        _hitCoordinates = new Vector3(_spotHit.point.x, 0, _spotHit.point.z);
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, _hitCoordinates);
    }
    
    public void SetLinePositionToZero()
    {
        Line.SetPosition(0, new Vector3(-50, -50, -50));
        Line.SetPosition(1, new Vector3(-50, -50, -50));
    }
}
/*
1 - Проверить, держим ли мы кнопку.
2 - Проверить, убрали ли мы мышку с игрока.
3 - Создать вектор в направлении точки удара с поверхностью.
4 - Добавить силу к игроку в направлении этого вектора.
*/