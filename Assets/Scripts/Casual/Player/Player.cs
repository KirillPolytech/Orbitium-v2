using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DragMovement))]
[RequireComponent(typeof(TrailRenderer))]
public class Player : MonoBehaviour
{
    [Range(1,100)][SerializeField] private float defaultStaminaValue = 100;
    [Range(0,1)][SerializeField] private float StaminaRegenVelocity = 0.5f;
    [Range(0,1)][SerializeField] private float LossStaminaVelocity = 0.1f; // 0.75f

    [SerializeField] private ParticleSystem _newDeathSystem;
    [SerializeField] private AudioSource hitSound;

    public int Collectables { get; private set; }

    public float Stamina { get; private set; } = 100;

    public bool IsDead { get; private set; }
    
    public bool IsWin { get; private set; }

    public bool GetGodModeState => _godMode;

    private bool _godMode;

    private enum Statements
    {
        Dead, Win, God, Playing
    }

    private Rigidbody _rb;
    private TrailRenderer _trailRenderer;
    
    private void Start()
    {
        _newDeathSystem.Stop();

        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        _trailRenderer = GetComponent<TrailRenderer>();
        _trailRenderer.startWidth = 1f;
        _trailRenderer.endWidth = 0.1f;

        // Settings after restart.
        IsDead = false;
        IsWin = false;
        Stamina = defaultStaminaValue;
        Collectables = 0;
        //
    }
    
    public void WasteStamina()
    {
        if (_godMode == false)
            Stamina = Mathf.Clamp(Stamina - LossStaminaVelocity, 0f , 100f);
    }
    
    public void RegenStamina()
    {
        Stamina = Mathf.Clamp(Stamina + StaminaRegenVelocity, 0f , 100f);
    }
    
    public void SetGodMode(bool condition)
    {
        _godMode = condition;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        PlayHitSound();
        if (_godMode == false)
            if ( (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Enemy") ) && IsWin == false )
                IsDead = true;
        if (collision.collider.CompareTag("Win") && IsDead == false && CollectablesManager.GetCountOfCollectables() == Collectables)
            IsWin = true;

        if (!IsDead) 
            return;
        
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Renderer>().enabled = false;
        _newDeathSystem.Play();
    }
    
    private void PlayHitSound()
    {
        hitSound.Play();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Collectables")) 
            return;

        Collectable collectable = other.gameObject.GetComponent<Collectable>();
        
        Collectables++;
        Stamina = Mathf.Clamp(Stamina + collectable.Value, 0, 100);
    }
}