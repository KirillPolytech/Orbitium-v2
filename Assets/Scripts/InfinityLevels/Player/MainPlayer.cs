using System;
using UnityEngine;

public class MainPlayer : MonoBehaviour, IStateConfigurator
{
    public Action EventAtDeath;
    public Action<int> EventAtCollect;

    [Range(0f,100)] [SerializeField] private float defaultStaminaValue = 100;
    [Range(0f, 100)] [SerializeField] private float stamina = 100;
    [Range(0f, 1f)] [SerializeField] private float Regen = 0.5f; // 0.5f
    [Range(0f, 1f)] [SerializeField] private float WasteStam = 0.75f; // 0.75f

    [SerializeField] private ParticleSystem _newDeathSystem;

    public int Collectables { get; private set; }
    public float Stamina => stamina;
    public Statements PlayerState { get; private set; } = Statements.Alive;

    private Rigidbody _rb;
    private AudioSource _hitSound;
    private Renderer _renderer;
    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _hitSound = GetComponent<AudioSource>();

        _newDeathSystem.Stop();

        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        // After Restart Settings.
        stamina = defaultStaminaValue;
        Collectables = 0;
        //
    }

    public void RotatePlayer(Vector3 dir)
    {
        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void WasteStamina()
    {
        if (PlayerState != Statements.God)
            stamina = Mathf.Clamp(stamina - WasteStam, 0f, 100f);
    }

    public void RegenStamina()
    {
        stamina = Mathf.Clamp(stamina + Regen, 0f, 100f);
    }

    public void SetGodMode(bool state)
    {
        PlayerState = state ? Statements.God : Statements.Alive;

        Debug.Log("god mode updated: " + PlayerState + " " + state);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Friend") == true)
        {
            stamina = Mathf.Clamp(stamina + 10, 0f, 100f);
        }

        PlayHitSound();
        if (PlayerState != Statements.God)
        {
            if (collision.collider.CompareTag(TagStorage.Wall) || collision.collider.CompareTag(TagStorage.Enemy))
            {
                PlayerState = Statements.Dead;
            }
        }

        if (PlayerState != Statements.Dead) 
            return;
        
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        _renderer.enabled = false;
        _newDeathSystem.Play();

        EventAtDeath.Invoke();
    }

    private void PlayHitSound()
    {
        _hitSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Collectables"))
            return;

        stamina = Mathf.Clamp(stamina + other.gameObject.GetComponent<CollectableSphereInfinity>().GetValuable, 0, 100);

        EventAtCollect?.Invoke(++Collectables);
    }

    public void SetState(bool state)
    {
        
    }

    public void Reset()
    {
        
    }
}