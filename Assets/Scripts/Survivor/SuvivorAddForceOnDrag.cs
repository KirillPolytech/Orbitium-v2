using UnityEngine;

public class SuvivorAddForceOnDrag : MonoBehaviour
{
    public float Force = 1f;
    public LineRenderer Line;

    private RaycastHit _spotHit;
    private Ray _cameraRay;
    private GameObject _playerGameObject;
    private SurvivorPlayer _survivalPlayer;
    private Rigidbody _playerRb;
    private Vector3 _direction;
    private Vector3 _hitCoordinates;
    private Vector2 _mousePosition;
    private const float _maxRayDistance = 3000f;
    private bool _isHoldingLeftButtonDown = false;
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _survivalPlayer = _playerGameObject.GetComponent<SurvivorPlayer>();
        _playerRb = _playerGameObject.GetComponent<Rigidbody>();

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
        _cameraRay = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(_cameraRay, out _spotHit, _maxRayDistance))
        {
            if (!_spotHit.collider.CompareTag("Player") && _isHoldingLeftButtonDown && _survivalPlayer.GetStamina() > 0f)
            {
                _direction = _spotHit.point - _playerGameObject.transform.position;
                _direction = new(_direction.x, 0, _direction.z);

                _playerRb.AddForce(_direction * Force, ForceMode.Impulse);

                _survivalPlayer.WasteStamina();

                SetLinePosition();
            }
            if (_survivalPlayer.GetStamina() <= 0f)
                SetLinePositionToZero();
        }
        if (!_isHoldingLeftButtonDown)
        {
            SetLinePositionToZero();

            _survivalPlayer.RegenStamina();
        }

        Debug.DrawLine(_cameraRay.origin, _spotHit.point, Color.red);
        Debug.DrawLine(_playerGameObject.transform.position, _spotHit.point, Color.blue);
    }
    private void SetLinePosition()
    {
        _hitCoordinates = new(_spotHit.point.x, 0, _spotHit.point.z);
        Line.SetPosition(0, _playerGameObject.transform.position);
        Line.SetPosition(1, _hitCoordinates);
    }
    public void SetLinePositionToZero()
    {
        Line.SetPosition(0, Vector3.zero);
        Line.SetPosition(1, Vector3.zero);
    }
}
/*
1 - Проверить, держим ли мы кнопку.
2 - Проверить, убрали ли мы мышку с игрока.
3 - Создать вектор в направлении точки удара с поверхностью.
4 - Добавить силу к игроку в направлении этого вектора.
*/

// IsHittedPlayer = (Physics.Raycast(_cameraRay, out _playerHit, _maxRayDistance) && _playerHit.collider.CompareTag("_survivalPlayer"));