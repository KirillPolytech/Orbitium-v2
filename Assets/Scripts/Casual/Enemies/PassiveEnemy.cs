using UnityEngine;

public class PassiveEnemy : MonoBehaviour
{
    public Vector3 TargetPosition;
    public float Velocity = 0.1f;

    private Vector3 _initialPosition;
    
    private void Start()
    {
        _initialPosition = transform.position;
    }
    
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(500, 0 , 0), Velocity);
        if (transform.position.x > (_initialPosition + TargetPosition).x )
            transform.position = _initialPosition;
    }
}
