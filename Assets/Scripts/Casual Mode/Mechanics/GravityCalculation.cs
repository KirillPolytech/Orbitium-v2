using UnityEngine;

public static class GravityCalculation
{
    private const int CriticalDistance = 1; // 5
    
    public static Vector3 CalculateGravity(Rigidbody current, Rigidbody other, float gravitationConstant)
    {
        Vector3 vectorToSun = current.transform.position - other.transform.position;
        float distanceToSun = vectorToSun.magnitude;
        Vector3 directionToSun = vectorToSun.normalized;
        float sunMass = current.mass;
        float otherMass = other.mass;

        float gravity;
        // F = G * (m1*m2) / R^2 (Gravity).
        if (distanceToSun * distanceToSun < CriticalDistance)
            gravity = sunMass * otherMass * gravitationConstant / CriticalDistance;
        else
            gravity = sunMass * otherMass * gravitationConstant / (distanceToSun * distanceToSun);

        return gravity * directionToSun;
    }
}
