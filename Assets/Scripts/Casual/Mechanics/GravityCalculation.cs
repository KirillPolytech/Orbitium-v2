using UnityEngine;

public class GravityCalculation
{
    private const float CriticalDistance = 5f;
    
    public static Vector3 CalculateGravityForce(Rigidbody other, Rigidbody current, float gravitationConstant)
    {
        Vector3 directionToSun = current.transform.position - other.transform.position;
        float distanceToPlanet = directionToSun.magnitude;
        directionToSun = directionToSun.normalized;
        float sunMass = current.transform.GetComponent<Rigidbody>().mass;
        float otherMass = other.gameObject.GetComponent<Rigidbody>().mass;
        
        // F = G * (m1*m2) / R^2 (Gravity).
        float gravity;
        if (distanceToPlanet * distanceToPlanet < CriticalDistance)
            gravity = sunMass * otherMass * gravitationConstant / CriticalDistance;
        else
            gravity = sunMass * otherMass * gravitationConstant / (distanceToPlanet * distanceToPlanet);

        return gravity * directionToSun;
    }
}