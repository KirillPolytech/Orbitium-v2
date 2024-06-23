using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [Range(0,5)] [SerializeField] private int ScrollForce = 5;
    [Range(20, 50)] [SerializeField] private int MaxHeight = 50;
    [Range(10, 25)] [SerializeField] private int MinHeight = 15;
    [Range(5, 25)] [SerializeField] private int ScrollSpeed = 5;
    [Range(0.0f, 1f)] [SerializeField] private float ChaseVelocity = 0.1f;

    private GameObject __playerObject;
    private float _isMouseScrolling;
    private void Start()
    {
        __playerObject = MainPlayer.Instance.gameObject;
    }

    private void Update()
    {
        _isMouseScrolling = Input.GetAxis(GlobalVariables.MouseScrollWheel) * ScrollSpeed;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(__playerObject.transform.position.x, Mathf.Clamp(transform.position.y - _isMouseScrolling * ScrollForce, MinHeight, MaxHeight) , __playerObject.transform.position.z),
            ChaseVelocity);
    }
}