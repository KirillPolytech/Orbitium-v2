using UnityEngine;

public class StaticPlanetInfinity : MonoBehaviour
{
    private AudioSource __staticPlanetSound;
    private GameObject _playerGameObject;
    private ForceOnDrag _addForceOnDrag;

    private Gravitation _otherGravityComponent;

    private Vector3 _gravityDirection = Vector3.zero;
    //
    private MovementPredictionInfinity __prediction;
    //
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _addForceOnDrag = _playerGameObject.GetComponent<ForceOnDrag>();
        __prediction = _playerGameObject.GetComponent<MovementPredictionInfinity>();

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