using UnityEngine;

public class SetOrbit : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.02f;
    private float currentRadian = 0f;
    private float x, z;
    private float radius = 10f;
    private Vector3 _center = Vector3.zero;
    private GameObject _player;
    private ForceOnDrag _addForce;
    const float RAD = 0.0174533f;
    private void Start()
    {
        _addForce = MainPlayer.Instance.GetComponent<ForceOnDrag>();

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
//((vector3ToObject.x * initialVector.x + vector3ToObject.z * initialVector.z) / Mathf.Sqrt(vector3ToObject.x * vector3ToObject.x + vector3ToObject.z * vector3ToObject.z) * Mathf.Sqrt(initialVector.x * initialVector.x + initialVector.z * initialVector.z) + 0.02f) * radius;