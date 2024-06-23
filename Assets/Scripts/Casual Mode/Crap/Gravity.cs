using UnityEngine;
public class Gravity : MonoBehaviour
{   
    public float GravitationConstant = 0.0000000008541557f;
    public GameObject Sun;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            // To Sun.
            Vector3 Vector3Distance = Sun.transform.position - other.transform.position;
            // Distance to sun.
            float DistanceToPlanet = Vector3Distance.magnitude;
            // Direction to sun.
            Vector3 DirectionToSun = Vector3Distance.normalized;

            float SunMass = Sun.GetComponent<Rigidbody>().mass;
            float OtherMass = other.gameObject.GetComponent<Rigidbody>().mass;
            // F = G * (m1*m2) / R^2 (Gravity).
            float Gravity = (SunMass * OtherMass) * GravitationConstant / (DistanceToPlanet * DistanceToPlanet);
            // Apply gravity.
            other.GetComponent<Rigidbody>().AddForce(Gravity * DirectionToSun, ForceMode.Acceleration);
        }
    }
    /*work
        Vector3 Vector3Distance = transform.position - other.transform.position;
        float GravityDistance = Vector3Distance.magnitude;
        Vector3 Direction = Vector3Distance.normalized;
        Vector3 Gravity = Gravitation * Direction / (GravityDistance * GravityDistance);
        other.GetComponent<Rigidbody>().AddForce(Gravity, ForceMode.Acceleration);
     */
}
// double lenght = Mathf.Sqrt(Mathf.Pow(Two.transform.position.x - One.transform.position.x, 2) + Mathf.Pow(Two.transform.position.y - One.transform.position.y, 2) + Mathf.Pow(Two.transform.position.z - One.transform.position.z, 2) );
// double F = G * (One.GetComponent<Rigidbody>().mass * Two.GetComponent<Rigidbody>().mass) / Distance.magnitude * Distance.magnitude;
// Vector3 Distance = Two.transform.position - One.transform.position;
// Vector3 Distance = DistanceBetweenTwoPoint(Two.transform.position, One.transform.position);
// public GameObject One, Two;
// const double G = 0.00000000006674;
