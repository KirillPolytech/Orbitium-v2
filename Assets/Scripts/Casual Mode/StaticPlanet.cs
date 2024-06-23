using UnityEngine;

public class StaticPlanet : MonoBehaviour
{
    private AudioSource _staticPlanetSound;
    private GameObject _playerGameObject;
    private DragMovement _dragMovement;
    private Gravitation _otherGravityComponent;
    private Vector3 _gravityDirection = Vector3.zero;
    
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _dragMovement = _playerGameObject.GetComponent<DragMovement>();

        _otherGravityComponent = GetComponentInChildren(typeof(Gravitation)) as Gravitation;

        _staticPlanetSound = GetComponent<AudioSource>();
        _staticPlanetSound.playOnAwake = true;
        _staticPlanetSound.loop = true;
        _staticPlanetSound.spatialBlend = 1;
        _staticPlanetSound.priority = 0;
        _staticPlanetSound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (!rb)
            return;
        
        rb.AddForce(new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)));
    }
    /*private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) 
            return;
        
        _gravityDirection = GravityCalculation.CalculateGravityForce() _otherGravityComponent.GravitationJobVector3(other.gameObject.GetComponent<Rigidbody>());

        _addForceOnDrag.SetGravityDirection(_gravityDirection);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _addForceOnDrag.SetGravityDirection(Vector3.zero);
        }
    }*/
}
