using UnityEngine;

public class AddForceOnClick : MonoBehaviour
{
    public LineRenderer Line;
    public float Force = 100f;

    private RaycastHit hit;
    private GameObject _SavedPlayerGameObject = null;
    private Vector3 _direction;
    private const float _maxRayDistance = 250f;
    private Ray ray;

    private bool IsHoldingLeftButtonDown = false;

    private Player _player;
    private void Start()
    {
        GameObject _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _player = _playerGameObject.GetComponent<Player>();

        Line.useWorldSpace = true;
        Line.startWidth = 1f;
        Line.endWidth = 0.3f;
    }
    private void Update()
    {
        IsHoldingLeftButtonDown = Input.GetButton("Fire1");
    }
    private void FixedUpdate()
    {
        IsHittedPlayer();
        IsLeftButtonHolding();
        AddForce();
        CheckStamina();
        Debbuging();
    }
    private void AddForce()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Двигаем объект в направлении курсора.
        if (Physics.Raycast(ray, out hit, _maxRayDistance) && IsHoldingLeftButtonDown && _SavedPlayerGameObject != null && hit.transform.gameObject != _SavedPlayerGameObject && _player.Stamina > 0f)
        {
            // Создаём вектор направления от объекта к новой точке.
            _direction = hit.point - _SavedPlayerGameObject.transform.position;
            // Обнуляем y координату, чтобы он не улетел вниз.
            _direction = new Vector3(_direction.x, 0, _direction.z);
            // Применяем к объекту силу.
            _SavedPlayerGameObject.transform.gameObject.GetComponent<Rigidbody>().AddForce(Force * Time.fixedDeltaTime * _direction, ForceMode.Impulse); // ForceMode.Acceleration

            SetLinePosition();

            _player.WasteStamina();
        }
    }
    private void Debbuging()
    {

        if (_SavedPlayerGameObject != null)
        {
            Debug.DrawLine(_SavedPlayerGameObject.transform.position, hit.point, Color.white);
            // Debug.DrawRay(_SavedPlayerGameObject.transform.position, _direction * _maxRayDistance, Color.white);
        }
        else
        {
            SetLineToZero();
        }
        Debug.DrawLine(ray.origin, hit.point, Color.red);
        //Debug.DrawRay(ray.origin, ray.direction * _maxRayDistance, Color.red);
    }
    private void CheckStamina()
    {
        if (_player.Stamina < 1f)
        {
            SetLineToZero();
        }

        // Stamina Regen.
        if (IsHoldingLeftButtonDown == false && _player.Stamina < 100f)
        {
            _player.RegenStamina();
        }
    }
    private void IsHittedPlayer()
    {
        // if (Physics.Raycast(ray, out hit, MaxRayDistance) && Input.GetButton("Fire1") && hit.collider.gameObject.GetComponent<Rigidbody>() != null && _SavedPlayerGameObject == null)
        if (Physics.Raycast(ray, out hit, _maxRayDistance) && IsHoldingLeftButtonDown && _SavedPlayerGameObject == null && hit.collider.gameObject.CompareTag("Player"))
        {
            _SavedPlayerGameObject = hit.transform.gameObject;
        }
    }
    private void IsLeftButtonHolding()
    {
        // Если отпустили лкм, то обнуляем объект.
        if (IsHoldingLeftButtonDown == false)
        {
            _SavedPlayerGameObject = null;
        }
    }
    private void SetLinePosition()
    {
        Vector3 _savedObjectCoordinates = new(_SavedPlayerGameObject.transform.position.x, 0, _SavedPlayerGameObject.transform.position.z);
        Vector3 _hitCoordinates = new(hit.point.x, 0, hit.point.z);
        Line.SetPosition(0, _savedObjectCoordinates);
        Line.SetPosition(1, _hitCoordinates);
    }
    private void SetLineToZero()
    {
        Line.SetPosition(0, Vector3.zero);
        Line.SetPosition(1, Vector3.zero);
    }
}