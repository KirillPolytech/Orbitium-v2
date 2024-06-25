using UnityEngine;

public static class GravityCalculation
{
    private const int CriticalDistance = 1;

    public static Vector3 CalculateGravity(Rigidbody current, Rigidbody other, float gravitationConstant)
    {
        Vector3 vectorToOther = current.transform.position - other.transform.position;

        float distToOther = vectorToOther.magnitude;
        Vector3 dirToOther = vectorToOther.normalized;

        float currentMass = current.mass;
        float otherMass = other.mass;

        float gravity;
        // F = G * (m1*m2) / R^2 (Gravity).
        if (distToOther * distToOther < CriticalDistance)
            gravity = currentMass * otherMass * gravitationConstant / CriticalDistance;
        else
            gravity = currentMass * otherMass * gravitationConstant / (distToOther * distToOther);

        return gravity * dirToOther;
    }

    public static Vector3 CalculateGravity(Rigidbody current, Rigidbody other, Vector3 currentPos, Vector3 otherPos,
        float gravitationConstant)
    {
        Vector3 vectorToOther = otherPos - currentPos;

        float distToOther = vectorToOther.magnitude;
        Vector3 dirToOther = vectorToOther.normalized;

        float currentMass = current.mass;
        float otherMass = other.mass;

        float gravity;
        // F = G * (m1*m2) / R^2 (Gravity).
        if (distToOther * distToOther < CriticalDistance)
            gravity = currentMass * otherMass * gravitationConstant / CriticalDistance;
        else
            gravity = currentMass * otherMass * gravitationConstant / (distToOther * distToOther);

        return gravity * dirToOther;
    }
}