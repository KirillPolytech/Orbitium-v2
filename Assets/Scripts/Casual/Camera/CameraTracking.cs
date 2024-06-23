using UnityEngine;
public class CameraTracking : MonoBehaviour
{
    [SerializeField] private int ScrollForce = 5;
    [SerializeField] private int MaxHeight = 50;
    [SerializeField] private int MinHeight = 50;


    private GameObject _playerObject;
    private float _isMouseScrolling;
    
    private void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        _isMouseScrolling = Input.GetAxis("Mouse ScrollWheel");
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(_playerObject.transform.position.x, transform.position.y, _playerObject.transform.position.z);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - _isMouseScrolling * ScrollForce, MinHeight, MaxHeight) , transform.position.z);
    }
}