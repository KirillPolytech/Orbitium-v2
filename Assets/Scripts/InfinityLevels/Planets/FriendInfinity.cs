using UnityEngine;

public class FriendInfinity : MonoBehaviour
{
    [Range(1,25)]
    [SerializeField] private int Velocity = 5;
    [SerializeField] private Material DestroyMaterial;

    private Rigidbody __rb;
    private GameObject __player;
    private Vector3 __direction;
    private void Awake()
    {
        __player = GameObject.FindGameObjectWithTag("Player");
        __rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        __direction = (__player.transform.position - transform.position).normalized * Velocity;
        __rb.velocity = __direction;        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            GameObject _tempGameObject = new("DestroyParticleSystem");
            _tempGameObject.AddComponent<ParticleSystem>();
            _tempGameObject.GetComponent<ParticleSystemRenderer>().material = DestroyMaterial;
            _tempGameObject.transform.position = collision.gameObject.transform.position;

            Destroy(gameObject);
        }
    }
}