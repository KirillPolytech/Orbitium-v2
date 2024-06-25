using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [Range(0,5)] [SerializeField] private int scrollForce = 5;
    [Range(20, 50)] [SerializeField] private int maxHeight = 50;
    [Range(10, 25)] [SerializeField] private int minHeight = 15;
    [Range(5, 25)] [SerializeField] private int scrollSpeed = 5;
    [Range(0.0f, 1f)] [SerializeField] private float chaseVelocity = 0.1f;

    public Camera Camera { get; private set; }

    private GameObject _playerObject;
    private float _isMouseScrolling;
    
    private void Start()
    {
        Camera = GetComponent<Camera>();
        _playerObject = FindAnyObjectByType<MainPlayer>().gameObject;
    }

    private void Update()
    {
        _isMouseScrolling = Input.GetAxis(GlobalVariables.MouseScrollWheel) * scrollSpeed;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(_playerObject.transform.position.x, Mathf.Clamp(transform.position.y - _isMouseScrolling * scrollForce, minHeight, maxHeight) , _playerObject.transform.position.z),
            chaseVelocity);
    }
}