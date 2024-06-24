using UnityEngine;

public class SetOrbitInfinity : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.02f;
    private float currentRadian = 0f;
    private float x, z;
    private float radius = 10f;
    private Vector3 _center = Vector3.zero;
    private GameObject _player;
    private DragMovement _addForce;
    const float RAD = 0.0174533f;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _addForce = _player.GetComponent<DragMovement>();

        _center = transform.parent.transform.position;
    }
    private Vector3 SetOnOrbit()
    {
        x = Mathf.Cos(currentRadian) * radius;
        z = Mathf.Sin(currentRadian) * radius;

        currentRadian += rotationSpeed;

        return new Vector3(x, 0, z) + _center;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F) && other.CompareTag("Player"))
        {
            _addForce.enabled = false;
            other.gameObject.transform.position = SetOnOrbit();
            return;
        }

        if (other.CompareTag("Player"))
        {
            radius = (other.transform.position - transform.parent.transform.position).magnitude;
        }
        _addForce.enabled = true;
    }
}