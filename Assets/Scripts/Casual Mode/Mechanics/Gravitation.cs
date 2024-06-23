using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField]private float GravitationConstant = 0.0000000008541557f;
    private int Limit = 1; // 5
    private Vector3 Vector3Distance;
    private Vector3 DirectionToSun;
    private float DistanceToPlanet, SunMass, OtherMass;
    private float Gravity;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
            GravitationJob(other.gameObject, transform.parent.gameObject);
    }
    public void GravitationJob(GameObject other, GameObject current)
    {
        // To Sun.
        Vector3Distance = transform.parent.position - other.transform.position;
        // Distance to sun.
        DistanceToPlanet = Vector3Distance.magnitude;
        // Direction to sun.
        DirectionToSun = Vector3Distance.normalized;
        SunMass = transform.parent.GetComponent<Rigidbody>().mass;
        OtherMass = other.gameObject.GetComponent<Rigidbody>().mass;
        // F = G * (m1*m2) / R^2 (Gravity).
        if (DistanceToPlanet * DistanceToPlanet < 5f)
            Gravity = (SunMass * OtherMass) * GravitationConstant / 5f;
        else
            Gravity = (SunMass * OtherMass) * GravitationConstant / (DistanceToPlanet * DistanceToPlanet);
        // Apply gravity.
        other.GetComponent<Rigidbody>().AddForce(Gravity * DirectionToSun, ForceMode.Impulse);
    }
    public Vector3 GravitationJobVector3(GameObject other)
    {
        // To Sun.
        Vector3Distance = transform.parent.position - other.transform.position;
        // Distance to sun.
        DistanceToPlanet = Vector3Distance.magnitude;
        // Direction to sun.
        DirectionToSun = Vector3Distance.normalized;
        SunMass = transform.parent.GetComponent<Rigidbody>().mass;
        OtherMass = other.gameObject.GetComponent<Rigidbody>().mass;
        // F = G * (m1*m2) / R^2 (Gravity).
        if (DistanceToPlanet * DistanceToPlanet < Limit)
            Gravity = (SunMass * OtherMass) * GravitationConstant / Limit;
        else
            Gravity = (SunMass * OtherMass) * GravitationConstant / (DistanceToPlanet * DistanceToPlanet);
        // Apply gravity.
        return Gravity * DirectionToSun;
    }

    [SerializeField] private LineRenderer circleRenderer;
    [Range(36,72)]
    [SerializeField] private int steps = 36;

    private float radius;
    private float currentRadian;
    private float x, z;

    Vector3 parentPosition;
    private void Start()
    {
        circleRenderer.useWorldSpace = true;
        radius = GetComponent<SphereCollider>().radius;
        //Debug.Log("radius: " + radius);
    }
    private void FixedUpdate()
    {
        DrawGravitationCircle();
    }
    private void DrawGravitationCircle()
    {
        circleRenderer.positionCount = steps;
        parentPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, transform.parent.transform.position.z);

        for (int i = 0; i < steps - 1; i++)
        {
            currentRadian = ( (float)i / steps ) * 2 * Mathf.PI;

            x = Mathf.Cos(currentRadian) * radius;
            z = Mathf.Sin(currentRadian) * radius;

            circleRenderer.SetPosition(i, parentPosition + new Vector3(x, 0, z));
        }
        x = Mathf.Cos(Mathf.PI * 2) * radius;
        z = Mathf.Sin(Mathf.PI * 2) * radius;
        circleRenderer.SetPosition(steps - 1, parentPosition + new Vector3(x, 0, z));

    }
}
// Vector3 currentPosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y);
//currentPosition = new Vector3(transform.parent.transform.position.x + x, transform.parent.transform.position.y, transform.parent.transform.position.z + y);
/*
private Vector3 currentPosition;
currentPosition = parentPosition + new Vector3(x, 0, z);

            xScaled = Mathf.Cos(currentRadian);
            yScaled = Mathf.Sin(currentRadian);

            circumferenceProgress = (float)i / steps;
*/

//WORK
//Gravity = (SunMass * OtherMass) * GravitationConstant / (DistanceToPlanet * DistanceToPlanet);


/* WORK
if (other.gameObject.GetComponent<Rigidbody>() != null)
{
    // To Sun.
    Vector3Distance = transform.parent.position - other.transform.position;
    // Distance to sun.
    DistanceToPlanet = Vector3Distance.magnitude;
    // Direction to sun.
    DirectionToSun = Vector3Distance.normalized;

    SunMass = transform.parent.GetComponent<Rigidbody>().mass;
    OtherMass = other.gameObject.GetComponent<Rigidbody>().mass;
    // F = G * (m1*m2) / R^2 (Gravity).
    //Gravity = (SunMass * OtherMass) * GravitationConstant / (DistanceToPlanet * DistanceToPlanet);
    if (DistanceToPlanet * DistanceToPlanet < 0.5f)
        Gravity = (SunMass * OtherMass) * GravitationConstant / 0.5f;
    else
        Gravity = (SunMass * OtherMass) * GravitationConstant / (DistanceToPlanet * DistanceToPlanet);
    // Apply gravity.
    other.GetComponent<Rigidbody>().AddForce(Gravity * DirectionToSun, ForceMode.Impulse);
}
*/