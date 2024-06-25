using UnityEngine;

public class LoadingImageRotation : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 0.02f;
    [SerializeField] private Vector3 RotationVector;
    void Update()
    {
        transform.Rotate(RotationVector * RotationSpeed);
    }
}
