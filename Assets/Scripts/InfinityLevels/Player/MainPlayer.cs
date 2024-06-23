using System;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer Instance { get; private set; }
    public Action EventAtDeath;

    [Range(0f,100)] [SerializeField] private float defaultStaminaValue = 100;
    [Range(0f, 100)] [SerializeField] private float stamina = 100;
    [Range(0f, 1f)] [SerializeField] private float Regen = 0.5f; // 0.5f
    [Range(0f, 1f)] [SerializeField] private float WasteStam = 0.75f; // 0.75f
    [SerializeField] private int Collectables = 0;

    [SerializeField] private ParticleSystem _newDeathSystem;

    public int GetCollectables  => Collectables;
    public float GetStamina => stamina;
    public Statements GetPlayerState => _playerState;

    private Statements _playerState = Statements.Alive;
    private Rigidbody _rb;
    private AudioSource _hitSound;
    private Renderer _renderer;
    public void Initialize()
    {
        if (Instance == null)
            Instance = this; 
        else 
            Destroy(gameObject);

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
        if (_playerState != Statements.God)
            stamina = Mathf.Clamp(stamina - WasteStam, 0f, 100f);
    }

    public void RegenStamina()
    {
        stamina = Mathf.Clamp(stamina + Regen, 0f, 100f);
    }

    public void SetGodMode(bool state)
    {
        if (state)
            _playerState = Statements.God;

        else
            _playerState = Statements.Alive;

        Debug.Log("godmode updated: " + _playerState + " " + state);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Friend") == true)
        {
            stamina = Mathf.Clamp(stamina + 10, 0f, 100f);
        }

        PlayHitSound();
        if (_playerState != Statements.God)
        {
            if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Enemy"))
            {
                _playerState = Statements.Dead;
            }
        }

        if (_playerState == Statements.Dead)
        {
            _rb.constraints = RigidbodyConstraints.FreezeAll;
            _renderer.enabled = false;
            _newDeathSystem.Play();

            EventAtDeath.Invoke();

            UIManager.Instance.EnableDeadScreen();
        }
    }

    private void PlayHitSound()
    {
        _hitSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectables") == false)
            return;

        Collectables++;

        stamina = Mathf.Clamp(stamina + other.gameObject.GetComponent<CollectableSphereInfinity>().GetValuable, 0, 100);

        UIManager.Instance.UpdateCollectablesText(Collectables);
    }
}
public enum Statements
{
    Dead, Alive, God, Playing
}