using UnityEngine;

public class StaticPlanet : MonoBehaviour
{
    private AudioSource _staticPlanetSound;
    private MovementPrediction _prediction;
    
    private void Start()
    {
        _staticPlanetSound = GetComponent<AudioSource>();
        
        _staticPlanetSound.playOnAwake = true;
        _staticPlanetSound.loop = true;
        _staticPlanetSound.spatialBlend = 1;
        _staticPlanetSound.priority = 0;
        _staticPlanetSound.Play();
    }
}