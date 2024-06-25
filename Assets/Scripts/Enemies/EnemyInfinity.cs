using UnityEngine;

public class EnemyInfinity : MonoBehaviour
{
    [Range(1, 25)] [SerializeField] private int velocity = 14;
    [SerializeField] private Material destroyMaterial;

    private Rigidbody _rb;
    private GameObject _player;
    private Vector3 _direction;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(TagStorage.Player);
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag(TagStorage.Player))
            return;

        _direction = (_player.transform.position - transform.position).normalized * velocity;
        _rb.velocity = _direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(TagStorage.Enemy) && !collision.gameObject.CompareTag(TagStorage.Player))
            return;

        GameObject tempGameObject = new GameObject("DeathParticleSystem");
        tempGameObject.AddComponent<ParticleSystem>();
        tempGameObject.GetComponent<ParticleSystemRenderer>().material = destroyMaterial;
        tempGameObject.transform.position = collision.gameObject.transform.position;

        Destroy(gameObject);
    }
}