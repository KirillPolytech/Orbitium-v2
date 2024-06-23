using UnityEngine;

public class CircleSpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private int ObjectsCount = 36;
    [SerializeField] private float Radius = 10f;
    [SerializeField] private Transform Center;

    private GameObject[] __instanceGameObject;
    private float currentRadian;
    private float x, z;
    private void Awake()
    {
        __instanceGameObject = new GameObject[ObjectsCount];
        for (int i = 0; i < ObjectsCount; i++)
        {
            __instanceGameObject[i] = Instantiate(Prefab, new Vector3(50, 50, 50), Quaternion.identity);
            __instanceGameObject[i].transform.parent = transform.parent;
        }
    }
    private void FixedUpdate()
    {
        SetCircle();
    }
    private void SetCircle()
    {
        for (int i = 0; i < ObjectsCount; i++)
        {
            currentRadian = (float)i / ObjectsCount * 2 * Mathf.PI;

            x = Mathf.Cos(currentRadian) * Radius;
            z = Mathf.Sin(currentRadian) * Radius;

            __instanceGameObject[i].transform.position = new Vector3(x, 0, z) + Center.position;//+ (transform.parent != null ? transform.parent.position : Vector3.zero);
        }
    }
}
