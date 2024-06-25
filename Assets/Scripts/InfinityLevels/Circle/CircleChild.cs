using UnityEngine;

public class CircleChild : MonoBehaviour
{
    private CircleRotation _circleRotation;
    
    private void Awake()
    {
        _circleRotation = transform.parent.GetComponent<CircleRotation>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagStorage.Destroyable))
            return;
        
        _circleRotation.StopRotation();
        Destroy(this);
    }
}
