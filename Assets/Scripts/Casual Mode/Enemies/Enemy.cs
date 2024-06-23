using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float Force = 1f;
    [SerializeField] private Material _destroyMaterial;
    [SerializeField] private int _interval = 50;

    private Rigidbody Rb;
    private GameObject Player;
    private Vector3 Direction;
    private int _timer = 0;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Direction = (Player.transform.position - transform.position).normalized;
            if (_timer > _interval)
            {
                Rb.AddForce(Direction * Force, ForceMode.Impulse);
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