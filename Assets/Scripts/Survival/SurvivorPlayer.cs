using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(SuvivorAddForceOnDrag))]
public class SurvivorPlayer : MonoBehaviour
{
    [Header("Stamina")]
    private float Stamina = 100;
    [SerializeField] private float Regen = 0.5f; // 0.5f
    [SerializeField] private float WasteStam = 0.75f; // 0.75f
    [Header("Statements")]
    private bool _isDead = false, _isWin = false, _godMode = false;

    private Rigidbody Rb;
    private TrailRenderer _trailRenderer;

    public float EatingSpeed = 0.1f;
    public float DyingSpeed = 0.1f;

    private Vector3 _newScale;
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.useGravity = false;
        Rb.constraints = RigidbodyConstraints.FreezePositionY;

        _trailRenderer = GetComponent<TrailRenderer>();
        _trailRenderer.startWidth = 1f;
        _trailRenderer.endWidth = 0f;

        // After Restart Settings.
        _isDead = false;
        _isWin = false;
        Stamina = 100;
        //
    }
    private void FixedUpdate()
    {
        if (GetSize() > 800)
            _isWin = true;
        if (GetSize() < 1)
        {
            _isDead = true;
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
    public void WasteStamina()
    {
        if (_godMode == false)
            Stamina = Mathf.Clamp(Stamina - WasteStam, 0f , 100f);
    }
    public void RegenStamina()
    {
        Stamina = Mathf.Clamp(Stamina + Regen, 0f , 100f);
    }
    public bool IsDeadStatement()
    {
        return _isDead;
    }
    public bool IsWinStatement()
    {
        return _isWin;
    }
    public float GetSize()
    {
        return transform.localScale.x;
    }
    public float GetStamina()
    {
        return Stamina;
    }
    public bool GetGodModeState()
    {
        return _godMode;
    }
    public void SetGodMode(bool Condition)
    {
        _godMode = Condition;
    }
    public void EatingOther()
    {
        _newScale = new(
            transform.localScale.x + EatingSpeed,
            transform.localScale.y + EatingSpeed,
            transform.localScale.z + EatingSpeed);

        transform.localScale = _newScale;
    }
    public void Dying()
    {
        if (transform.localScale.x >= 0.5f && GetGodModeState() == false)
        {
            _newScale = new(
                transform.localScale.x - DyingSpeed,
                transform.localScale.y - DyingSpeed,
                transform.localScale.z - DyingSpeed);

            transform.localScale = _newScale;
        }
    }
    public void Death()
    {
        if (transform.localScale.x < 0.5f)
        {
            _isDead = true;            
        }
    }
}
/*
public float WinCollectables = 2f;
public GameObject WinCanvas;
*/
/*
        if (Collectables == WinCollectables)
        {
            WinCanvas.SetActive(true);
            Time.timeScale = 0;
        }
*/

// WinUI.SetActive(true);

/*
GetComponent<AddForceOnClick>().enabled = false;
GameOverUIScreen.SetActive(true);
Camera.main.GetComponent<CameraTracking>().Line.enabled = false;
*/

/*
if (Timer == 5)
{
    Timer = 0;
    //Debug.Log(Stamina + " " + StaminaImage.fillAmount);
}
Timer++;
*/