using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SphereCollider))]
public class CollectableSphereInfinity : MonoBehaviour
{
    [SerializeField] private int valuable = 10;

    [SerializeField] private ParticleSystem _CollectEffect;

    //[SerializeField] private float _fadeSpeed = 0.18f;
    public int GetValuable => valuable;

    private AudioSource _sound;
    private SphereCollider _sphereCollider;
    private float _fadeSpeed = 1f; // 0.9f

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        SendScore();
        PlaySound();
        _CollectEffect.transform.position = transform.position;
        //_CollectEffect.Play();
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
        Renderer renderer = GetComponent<Renderer>();
        Color c = renderer.material.color;
        Material m = renderer.material;
        for (; m.GetColor("_EmissionColor").r > 0;)
        {
            //Debug.Log(m.GetColor("_EmissionColor"));
            m.SetVector("_EmissionColor",
                m.GetColor("_EmissionColor") - new Color(_fadeSpeed, _fadeSpeed, _fadeSpeed, _fadeSpeed));
            renderer.material = m;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (float alpha = 1f; alpha > 0; alpha -= 0.10f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}