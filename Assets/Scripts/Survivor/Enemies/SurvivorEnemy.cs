using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class SurvivorEnemy : MonoBehaviour
{
    public float EatingSpeed = 0.1f;
    [SerializeField] private float DyingSpeed = 0.1f;
    [Header("Velocities")]
    public float MinStartSpeed = 1f;
    public float MaxStartSpeed = 10f;
    [Header("Sizes")]
    public float EnemiesMinSize = 1f;
    public float EnemiesMaxSize = 5f;

    public int Speed = 10;

    private Rigidbody Rb;
    private Vector3 _startDirection;
    private GameObject _Player;
    private float _startSize;
    private Renderer _renderer;

    private float _deathSize = 1f;

    private int Timer = 0;

    private FindingNearestEnemy _findingNearestEnemy;
    private void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        Rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();

        _findingNearestEnemy = transform.GetChild(1).GetComponent<FindingNearestEnemy>();

        _startSize = Random.Range(EnemiesMinSize, EnemiesMaxSize);
        transform.localScale = new(_startSize,_startSize,_startSize);

        _startDirection = new(Random.Range(MinStartSpeed, MaxStartSpeed), Random.Range(MinStartSpeed, MaxStartSpeed), Random.Range(MinStartSpeed, MaxStartSpeed));
        // Rb.AddForce(_startDirection * Random.Range(MinStartSpeed, MaxStartSpeed));

        Rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        Rb.useGravity = false;

        DyingSpeed = Random.Range(0.1f, 1f);
    }
    private void FixedUpdate()
    {
        IsSmallerThanPlayer();
        AddForce();
    }
    private void AddForce()
    {
        if (Timer >= 0)
        {
            if (_findingNearestEnemy.GetNearestEnemy())
            {
                if (_findingNearestEnemy.GetNearestEnemy().transform.localScale.x < transform.localScale.x)
                {
                    Rb.AddForce((_findingNearestEnemy.GetNearestEnemy().transform.position - transform.position).normalized * Speed, ForceMode.Acceleration);
                }else
                {
                    Rb.AddForce(-(_findingNearestEnemy.GetNearestEnemy().transform.position - transform.position).normalized * Speed * 2, ForceMode.Acceleration);
                }
            }else
            {
                Rb.AddForce(new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f) ) * Speed, ForceMode.Acceleration);
            }
            Timer = 0;
        }
        Timer++;
    }
    private void IsSmallerThanPlayer()
    {
        _renderer.material.color = _Player.transform.localScale.x > transform.localScale.x ?  new Color(5, 5, 5) : new Color(5, 0, 0);
    }
    public void EatingOther()
    {
        transform.localScale = new(
            transform.localScale.x + EatingSpeed,
            transform.localScale.y + EatingSpeed,
            transform.localScale.z + EatingSpeed);
    }
    public float GetDyingSpeed()
    {
        return DyingSpeed;
    }
    public void Dying()
    {
        if (transform.localScale.x >= _deathSize)
        {
            transform.localScale = new(
                transform.localScale.x - DyingSpeed,
                transform.localScale.y - DyingSpeed,
                transform.localScale.z - DyingSpeed);
        }
    }
    public void Death()
    {
        if (transform.localScale.x < _deathSize)
        {
            Destroy(gameObject);
        }
    }
}

/*
private void OnTriggerStay(Collider other)
{
    if (other.gameObject.CompareTag("Enemy"))
    {
        if (other.gameObject.transform.localScale.x > transform.localScale.x)
        {
            Dying();
            Death();
        }
        else
        {
            EatingOther(other.gameObject);
            other.gameObject.GetComponent<Enemies>().Dying();

            Debug.Log("Eating");
        }
    }
}
*/
/*
if (_Player.transform.localScale.x > transform.localScale.x)
{
    _renderer.material.color = new(5, 5, 5);
}
else
{
    _renderer.material.color = new(5,0,0);
}
*/
// _renderer.material.color = Color.Lerp(_renderer.material.color, _Player.transform.localScale.x > transform.localScale.x ? new Color(5, 5, 5) : new Color(5, 0, 0), 0.5f );
/*
 * 
 *     private EnemySpawner _enemySpawner;
if (_enemySpawner.NearestEnemyToObject(gameObject, 50) != null)
{
    Rb.AddForce( ( _enemySpawner.NearestEnemyToObject(gameObject, 50).transform.position - transform.position ).normalized * Speed, ForceMode.Acceleration);
}
else
{
    _randomDirection = new(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
    Rb.AddForce(_randomDirection * Speed, ForceMode.Acceleration);
}    
*/
