using UnityEngine;

public class CircleChild : MonoBehaviour
{
    private CircleRotation __circleRotation;
    private void Awake()
    {
        __circleRotation = transform.parent.GetComponent<CircleRotation>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyable"))
            return;
        __circleRotation.StopRotation();
        Destroy(this);
    }
}
