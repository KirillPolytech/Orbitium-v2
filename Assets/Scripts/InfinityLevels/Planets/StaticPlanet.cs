using UnityEngine;

public class StaticPlanet : MonoBehaviour
{
    private AudioSource _staticPlanetSound;
    private Gravitation _gravity;
    private MovementPredictionInfinity _prediction;
    private Rigidbody _rb;
    
    private void Start()
    {
        _gravity = GetComponentInChildren(typeof(Gravitation)) as Gravitation;
        _rb = GetComponent<Rigidbody>();
        _staticPlanetSound = GetComponent<AudioSource>();
        
        _staticPlanetSound.playOnAwake = true;
        _staticPlanetSound.loop = true;
        _staticPlanetSound.spatialBlend = 1;
        _staticPlanetSound.priority = 0;
        _staticPlanetSound.Play();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)));
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag(TagStorage.PlayerTag)) 
            return;

        Vector3 gravityDirection = GravityCalculation.CalculateGravity(_rb, other.GetComponent<Rigidbody>(), _gravity.GravityConstant );

        other.GetComponent<DragMovement>().SetGravityDirection(gravityDirection);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(TagStorage.PlayerTag))
            return;
        
        Vector3 gravityDirection = GravityCalculation.CalculateGravity(_rb, other.GetComponent<Rigidbody>(), _gravity.GravityConstant );
        other.GetComponent<DragMovement>().SetGravityDirection(gravityDirection);
    }
}