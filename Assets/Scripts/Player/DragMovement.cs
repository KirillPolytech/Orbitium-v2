using UnityEngine;

[RequireComponent(typeof(MovementDirectionLine))]
public class DragMovement : MonoBehaviour, IStateConfigurator, ITrajectoryChanger
{
    private const float MaxRayDistance = 500f;

    //public event EventOn

    [Range(0, 0.05f)] [SerializeField] private float force = 1f;

    private MovementDirectionLine _line;
    private MainPlayer _player;
    private CameraTracking _cameraTracking;
    private StaminaController _staminaController;
    private Trajectory _trajectory;
    private bool _isHoldingLeftButtonDown;
    private Vector2 _mousePosition;
    private Rigidbody _rb, _otherRb;
    private float _gravityConst;
    private Vector3 _gravityDirection, _lastPosition;
    private bool _isEnabled;

    public void Awake()
    {
        _player = GetComponent<MainPlayer>();
        _rb = GetComponent<Rigidbody>();
        _line = GetComponent<MovementDirectionLine>();
        _staminaController = GetComponent<StaminaController>();
        _trajectory = GetComponent<Trajectory>();
        _cameraTracking = FindAnyObjectByType<CameraTracking>();

        _lastPosition = _player.transform.position;

        _player.EventAtDeath += () => Destroy(this);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (!_isEnabled)
            return;

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

        Vector3 otherPos = !_otherRb ? Vector3.zero : _otherRb.transform.position;
        
        _trajectory.ShowTrajectory(_rb, _otherRb, transform.position, otherPos, _gravityConst);

        DragForce();
    }

    private void DragForce()
    {
        Ray cameraRay = _cameraTracking.Camera.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(cameraRay, out var spotHit, MaxRayDistance))
        {
            if (!spotHit.collider.CompareTag(TagStorage.Player) && _isHoldingLeftButtonDown &&
                _staminaController.StaminaNormalized > 0f)
            {
                Vector3 direction = spotHit.point - transform.position;
                direction.y = 0;

                _rb.velocity += direction * force + _gravityDirection;

                _staminaController.Waste();

                _line.SetLinePosition(spotHit, gameObject);
            }

            if (_staminaController.StaminaNormalized <= 0f)
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

    public void AddTrajectory(Vector3 gravityDirection, Rigidbody otherRb, float gravityConst)
    {
        _gravityDirection = gravityDirection;
        
        _rb.velocity += gravityDirection;

        _otherRb = otherRb;

        _gravityConst = gravityConst;
    }

    public void AddTrajectory(Vector3 direction)
    {
        _rb.velocity += direction;
    }
}