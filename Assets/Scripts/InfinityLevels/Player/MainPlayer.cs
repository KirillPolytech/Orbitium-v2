using System;
using UnityEngine;

public class MainPlayer : MonoBehaviour, IStateConfigurator
{
    public Action EventAtDeath;
    public Action<int> EventAtCollect;
    
    [SerializeField] private ParticleSystem deathParticleSystem;

    public int Collectables { get; private set; }
    public Statements PlayerState { get; private set; } = Statements.Alive;

    private Rigidbody _rb;
    private AudioSource _hitSound;
    private Renderer _renderer;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _hitSound = GetComponent<AudioSource>();

        deathParticleSystem.Stop();

        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        Collectables = 0;
    }

    public void RotatePlayer(Vector3 dir)
    {
        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void SetGodMode(bool state)
    {
        PlayerState = state ? Statements.God : Statements.Alive;

        Debug.Log($"God mode updated: {PlayerState} {state})");
    }

    private void OnCollisionEnter(Collision collision)
    {
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
        deathParticleSystem.Play();

        EventAtDeath.Invoke();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Collectables"))
            return;
        
        EventAtCollect?.Invoke(++Collectables);
    }

    private void PlayHitSound()
    {
        _hitSound.Play();
    }

    public void SetState(bool state)
    {
    }

    public void Reset()
    {
    }
}