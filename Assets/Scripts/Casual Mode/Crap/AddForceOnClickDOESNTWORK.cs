using UnityEngine;
public class AddForceOnClickDOESNTWORK : MonoBehaviour
{
    /*
    RaycastHit Hit;
    GameObject SavedObject = null;
    Vector3 Direction;
    const float MaxRayDistance = 250f;
    Ray ray;

    public LineRenderer Line;
    public float Force = 100f;
    //
    public GameObject PlayerGO;
    Player player;
    //
    private void Start()
    {
        //
        player = PlayerGO.GetComponent<Player>();
        //
        Line.useWorldSpace = true;
        Line.startWidth = 1f;
        Line.endWidth = 0.3f;
    }
    private void FixedUpdate()
    {
        AddForce();
    }
    void AddForce()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out Hit, MaxRayDistance) && Input.GetButton("Fire1") && Hit.collider.gameObject.GetComponent<Rigidbody>() != null && SavedObject == null)
        {
            if (Hit.collider.gameObject.CompareTag("Player"))
            {
                SavedObject = Hit.transform.gameObject;
            }
        }
        // Если отпустили лкм, то обнуляем объект.
        if (!Input.GetButton("Fire1"))
        {
            SavedObject = null;
        }
        // Двигаем объект в направлении курсора.
        if (Physics.Raycast(ray, out Hit, MaxRayDistance) && Input.GetButton("Fire1") && SavedObject != null && Hit.transform.gameObject != SavedObject && player.Stamina > 0f)
        {
            // Создаём вектор направления от объекта к новой точке.
            Direction = Hit.point - SavedObject.transform.position;
            // Обнуляем y координату, чтобы он не улетел вниз.
            Direction = new Vector3(Direction.x, 0, Direction.z);
            // Применяем к объекту силу.
            SavedObject.transform.gameObject.GetComponent<Rigidbody>().AddForce(Force * Time.fixedDeltaTime * Direction, ForceMode.Impulse); // ForceMode.Acceleration

            Vector3 SavedObjectCoord = new(SavedObject.transform.position.x, 0, SavedObject.transform.position.z);
            Vector3 HitCoord = new(Hit.point.x, 0, Hit.point.z);
            Line.SetPosition(0, SavedObjectCoord);
            Line.SetPosition(1, HitCoord);
            // Stamina.
            if ( player.Stamina > 0f)
            {
                player.Stamina -= player.Waste;
                player.StaminaImage.fillAmount -= player.Waste / 100f;
            }
        }else if (player.Stamina < 1f)
        {
            Line.SetPosition(0, Vector3.zero);
            Line.SetPosition(1, Vector3.zero);
        }
        // Stamina Regen.
        if (!Input.GetButton("Fire1") && player.Stamina < 100f)
        {
            player.Stamina += player.Regen;
            player.StaminaImage.fillAmount += player.Regen / 100f;
        }

        if (SavedObject != null)
        {
            Debug.DrawRay(SavedObject.transform.position, Direction * MaxRayDistance, Color.white);
        }
        else
        {
            Line.SetPosition(0, Vector3.zero);
            Line.SetPosition(1, Vector3.zero);
        }
        Debug.DrawRay(ray.origin, ray.direction * MaxRayDistance, Color.red);
    }
    */
}
