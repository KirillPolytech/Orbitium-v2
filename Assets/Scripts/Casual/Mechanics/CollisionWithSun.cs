using UnityEngine;

public class CollisionWithSun : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
