using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Force = 1f;
    [SerializeField] private Material _destroyMaterial;
    [SerializeField] private int _interval = 50;

    private Rigidbody _rb;
    private GameObject _player;
    private Vector3 _direction;
    private int _timer;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _direction = (_player.transform.position - transform.position).normalized;
            if (_timer > _interval)
            {
                _rb.AddForce(_direction * Force, ForceMode.Impulse);
                _timer = 0;
            }

            _timer++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            GameObject _tempGameObject = new("DestroyParticleSystem");
            _tempGameObject.AddComponent<ParticleSystem>();
            _tempGameObject.GetComponent<ParticleSystemRenderer>().material = _destroyMaterial;
            _tempGameObject.transform.position = collision.gameObject.transform.position;

            Destroy(gameObject);
        }
    }
}
/*
 *     [SerializeField] private float Range = 10f;
    [SerializeField] private int ForceTime = 50;
float Distance = (Player.transform.position - transform.position).magnitude;
if (Distance < Range && ForceTime >= 0)
{
    Direction = Player.transform.position - transform.position;
    Rb.AddForce(Direction * Force, ForceMode.Acceleration);
    ForceTime--;
}
*/
//[SerializeField] private ParticleSystem _destroyEffect;