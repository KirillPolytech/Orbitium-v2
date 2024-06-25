using UnityEngine;

public class StaminaController : MonoBehaviour
{
    [Range(0f, 100)] [SerializeField] private float defaultStaminaValue = 100;
    [Range(0f, 100)] [SerializeField] private float stamina = 100;
    [Range(0f, 1f)] [SerializeField] private float regen = 0.5f;
    [Range(0f, 1f)] [SerializeField] private float wasteStam = 0.1f;

    public float StaminaNormalized => stamina / 100;

    private MainPlayer _mainPlayer;

    private void Awake()
    {
        _mainPlayer = GetComponent<MainPlayer>();

        stamina = defaultStaminaValue;
    }

    public void Waste()
    {
        if (_mainPlayer.PlayerState == Statements.God)
            return;

        stamina = Mathf.Clamp(stamina - wasteStam, 0f, 100f);
    }

    public void Regen()
    {
        stamina = Mathf.Clamp(stamina + regen, 0f, 100f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(TagStorage.Friend))
            return;
        
        stamina = Mathf.Clamp(stamina + 10, 0f, 100f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Collectables"))
            return;

        stamina = Mathf.Clamp(stamina + other.gameObject.GetComponent<CollectableSphereInfinity>().GetValuable, 0, 100);
    }
}