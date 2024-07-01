using UnityEngine;

public class StaticPlanet : MonoBehaviour
{
    [Range(0,100)][SerializeField] private float knockForce = 5;
    
    private AudioSource _staticPlanetSound;
    
    private void Start()
    {
        _staticPlanetSound = GetComponent<AudioSource>();
        
        _staticPlanetSound.playOnAwake = true;
        _staticPlanetSound.loop = true;
        _staticPlanetSound.spatialBlend = 1;
        _staticPlanetSound.priority = 0;
        _staticPlanetSound.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        HandleCollisionLogic(other);
    }
    
    private void OnCollisionStay(Collision other)
    {
        HandleCollisionLogic(other);
    }

    private void HandleCollisionLogic(Collision other)
    {
        ITrajectoryChanger trajectoryChanger = other.gameObject.GetComponent<ITrajectoryChanger>();
        
        if (trajectoryChanger == null)
            return;

        Vector3 direction = (other.transform.position - transform.position).normalized * knockForce;
        
        trajectoryChanger.AddTrajectory(direction);
    }
}