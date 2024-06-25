using UnityEngine;

[RequireComponent(typeof(MovementDirectionLine))]
public class DragMovement : MonoBehaviour, IStateConfigurator
{
    private const float MaxRayDistance = 500f;
    
    [Range(0,1f) ][SerializeField] private float Force = 1f;

    private bool _isHoldingLeftButtonDown;
    private Vector2 _mousePosition;
    private MainPlayer _player;
    private Rigidbody _rb;
    private Vector3 _gravityDirection = Vector3.zero;
    private Vector3 _lastPosition;
    private MovementDirectionLine _line;
    private bool _isEnabled;
    
    public void Awake()
    {
        _player = GetComponent<MainPlayer>();
        _rb = GetComponent<Rigidbody>();
        _line = GetComponent<MovementDirectionLine>();

        _lastPosition = _player.transform.position;

        _player.EventAtDeath += () => Destroy(this);
    }
    
    private void Update()
    {
        _isHoldingLeftButtonDown = Input.GetButton(GlobalVariables.LeftMouseButton);

        _mousePosition = Input.mousePosition;
    }
    
    private void FixedUpdate()
    {
        if (!_isEnabled)
            return;
        
        if (_player.transform.position - _lastPosition != Vector3.zero)
        {
            _player.RotatePlayer(_player.transform.position - _lastPosition);
        }

        _lastPosition = _player.transform.position;

        DragForce();
    }
    
    public void SetGravityDirection(Vector3 gravityDirection)
    {
        _gravityDirection = gravityDirection;
    }
    
    private void DragForce()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(cameraRay, out var spotHit, MaxRayDistance))
        {
            if (!spotHit.collider.CompareTag("Player") && _isHoldingLeftButtonDown && _player.Stamina > 0f)
            {
                Vector3 direction = spotHit.point - transform.position;
                direction.y = 0;

                _rb.velocity = direction * Force + _gravityDirection;

                _player.WasteStamina();

                _line.SetLinePosition(spotHit, gameObject);
            }

            if (_player.Stamina <= 0f)
            {
                _line.ResetLinePosition();
            }
        }
        
        if (!_isHoldingLeftButtonDown)
        {
            _line.ResetLinePosition();
        }

        Debug.DrawLine(cameraRay.origin, spotHit.point, Color.red);
        Debug.DrawLine(transform.position, spotHit.point, Color.blue);
    }

    public void SetState(bool state)
    {
        _isEnabled = state;
    }

    public void Reset()
    {
        _isEnabled = true;
    }
}
/*
1 - Проверить, держим ли мы кнопку.
2 - Проверить, убрали ли мы мышку с игрока.
3 - Создать вектор в направлении точки удара с поверхностью.
4 - Добавить силу к игроку в направлении этого вектора.
*/