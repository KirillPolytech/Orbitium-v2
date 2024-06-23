using UnityEngine;

public class SurvivorCamera : MonoBehaviour
{
    public int ScrollForce = 5;
    //[SerializeField] private int MaxHeight = 50;
    //[SerializeField] private int MinHeight = 50;

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
        transform.position = new(_playerObject.transform.position.x, transform.position.y, _playerObject.transform.position.z);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - _isMouseScrolling * ScrollForce, _playerObject.transform.localScale.x * 2, _playerObject.transform.localScale.x * 10) , transform.position.z);
        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - _isMouseScrolling * ScrollForce, MinHeight, MaxHeight), transform.position.z);
    }
}
/*
if (_isMouseScrolling < 0 && transform.position.y < 50)
{
    transform.position += new Vector3(0, 1 * ScrollForce, 0);
}
else if (_isMouseScrolling > 0 && transform.position.y > 10)
{
    transform.position -= new Vector3(0, 1 * ScrollForce, 0);
}
*/
//transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - _isMouseScrolling * ScrollForce, _playerObject.transform.localScale.x * 2, _playerObject.transform.localScale.x * 10) , transform.position.z);
