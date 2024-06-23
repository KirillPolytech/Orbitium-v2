using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    [SerializeField] private float RotationVelocity = 1f;
    private Vector3 RotationDirection;
    private bool __isRotating = true;
    private void Awake()
    {
        RotationDirection = new Vector3(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));
    }
    private void FixedUpdate()
    {
        if (!__isRotating)
            return;

        transform.Rotate(RotationDirection * RotationVelocity);
    }
    public void StopRotation()
    {
        __isRotating = false;
        //Debug.Log("StopRotation");
    }
}
