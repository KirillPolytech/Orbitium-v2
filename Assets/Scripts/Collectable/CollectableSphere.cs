using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SphereCollider))]
public class CollectableSphere : MonoBehaviour
{
    [SerializeField] private int valuable = 10;
    [SerializeField] private ParticleSystem _CollectEffect;
    //[SerializeField] private float _fadeSpeed = 0.18f;
    private float _fadeSpeed = 1f; // 0.9f
    public int GetValuable { get { return valuable; } }

    private AudioSource _sound;
    private MeshRenderer _meshRenderer;
    private SphereCollider _sphereCollider;
    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _sphereCollider = GetComponent<SphereCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SendScore();
            PlaySound();
            _CollectEffect.transform.position = transform.position;
            _CollectEffect.Play();
            //_meshRenderer.enabled = false;
            _sphereCollider.enabled = false;
            StartCoroutine(Fade());
        }
    }
    private void SendScore()
    {
        Score.AddScore(valuable);
    }
    private void PlaySound()
    {
        _sound.Play();
    }

    IEnumerator Fade()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color c = renderer.material.color;
        Material m = renderer.material;
        for (; m.GetColor("_EmissionColor").r > 0;)
        {
            //Debug.Log(m.GetColor("_EmissionColor"));
            m.SetVector("_EmissionColor", m.GetColor("_EmissionColor") - new Color(_fadeSpeed, _fadeSpeed, _fadeSpeed, _fadeSpeed));//new Vector4(_fadeSpeed, _fadeSpeed, _fadeSpeed, _fadeSpeed) );
            renderer.material = m;
            yield return new WaitForSeconds(0.02f);
        }
        for (float alpha = 1f; alpha > -0.2f; alpha -= 0.10f)//0.05f
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }
}