using UnityEngine;

public class StaticPlanet : MonoBehaviour
{
    private AudioSource __staticPlanetSound;
    private ForceOnDrag _addForceOnDrag;

    private Gravitation _otherGravityComponent;

    private Vector3 _gravityDirection = Vector3.zero;
    private void Start()
    {
        _addForceOnDrag = MainPlayer.Instance.GetComponent<ForceOnDrag>();

        _otherGravityComponent = GetComponentInChildren(typeof(Gravitation)) as Gravitation;

        __staticPlanetSound = GetComponent<AudioSource>();
        __staticPlanetSound.playOnAwake = true;
        __staticPlanetSound.loop = true;
        __staticPlanetSound.spatialBlend = 1;
        __staticPlanetSound.priority = 0;
        __staticPlanetSound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gravityDirection = _otherGravityComponent.GravitationJobVector3(other.gameObject);

            _addForceOnDrag.SetGravityDirection(_gravityDirection);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _addForceOnDrag.SetGravityDirection(Vector3.zero);
        }
    }
}
