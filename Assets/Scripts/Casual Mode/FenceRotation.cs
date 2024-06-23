using UnityEngine;

public class FenceRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.02f;
    private void FixedUpdate()
    {
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + rotationSpeed, transform.rotation.z, transform.rotation.w);
    }
}
