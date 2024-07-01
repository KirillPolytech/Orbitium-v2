using UnityEngine;

public static class GravityCalculation
{
    private const float CriticalDistance = 1f;

    public static Vector3 CalculateGravity(Rigidbody current, Rigidbody other, float gravitationConstant, float radius)
    {
        Vector3 vectorToOther = current.transform.position - other.transform.position;

        float distToOther = vectorToOther.magnitude;
        Vector3 dirToOther = vectorToOther.normalized;

        float currentMass = current.mass;
        float otherMass = other.mass;

        // F = G * (m1*m2) / R^2 (Gravity).
        float gravity = distToOther * distToOther < radius
            ? currentMass * otherMass * gravitationConstant / CriticalDistance
            : currentMass * otherMass * gravitationConstant / (distToOther * distToOther);

        return gravity * dirToOther;
    }

    public static Vector3 CalculateGravity(Rigidbody current, Rigidbody other, Vector3 currentPos, Vector3 otherPos,
        float gravitationConstant, float radius)
    {
        Vector3 vectorToOther = otherPos - currentPos;

        float distToOther = vectorToOther.magnitude;
        Vector3 dirToOther = vectorToOther.normalized;

        float currentMass = current.mass;
        float otherMass = other ? other.mass : 0;

        // F = G * (m1*m2) / R^2 (Gravity).
        float gravity = distToOther * distToOther < radius
            ? currentMass * otherMass * gravitationConstant / CriticalDistance
            : currentMass * otherMass * gravitationConstant / (distToOther * distToOther);

        return gravity * dirToOther;
    }

    private static float CalculateGravityValue(float distToOther, float radius, float currentMass, float otherMass,
        float gravitationConstant)
    {
        // F = G * (m1*m2) / R^2 (Gravity).
        float gravity = distToOther * distToOther < radius
            ? currentMass * otherMass * gravitationConstant / radius
            : currentMass * otherMass * gravitationConstant / (distToOther * distToOther);

        return gravity;
    }
}