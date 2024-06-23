using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SphereCollider))]
public class CollectableSphereInfinity : Collectable
{
    [SerializeField] private ParticleSystem _CollectEffect;
    //[SerializeField] private float _fadeSpeed = 0.18f;

    private float _fadeSpeed = 1f; // 0.9f
    private AudioSource _sound;
    private SphereCollider _sphereCollider;
    private Renderer _renderer;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
        GetComponent<MeshRenderer>();
        _renderer = GetComponent<Renderer>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        SendScore();
        PlaySound();
        _CollectEffect.transform.position = transform.position;
        _CollectEffect.Play();
        //_meshRenderer.enabled = false;
        _sphereCollider.enabled = false;
        StartCoroutine(Fade());

        CollectablesCounter.AddCollectablesToList(gameObject);
    }

    private void SendScore()
    {
        Score.AddScore(valuable);
    }

    private void PlaySound()
    {
        _sound.Play();
    }

    private IEnumerator Fade()
    {
        Color c = _renderer.material.color;
        Material m = _renderer.material;
        for (; m.GetColor(EmissionColor).r > 0;)
        {
            //Debug.Log(m.GetColor("_EmissionColor"));
            m.SetVector(EmissionColor,
                m.GetColor(EmissionColor) -
                new Color(_fadeSpeed, _fadeSpeed, _fadeSpeed,
                    _fadeSpeed)); //new Vector4(_fadeSpeed, _fadeSpeed, _fadeSpeed, _fadeSpeed) );
            
            _renderer.material = m;
            yield return new WaitForSeconds(0.02f);
        }

        for (float alpha = 1f; alpha > -0.2f; alpha -= 0.10f) //0.05f
        {
            c.a = alpha;
            _renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }
}