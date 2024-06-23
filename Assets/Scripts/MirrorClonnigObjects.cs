using UnityEngine;

[ExecuteInEditMode]
public class MirrorClonnigObjects : MonoBehaviour
{
    [SerializeField] private GameObject mirrorGameObject;
    void Update()
    {
        mirrorGameObject.transform.position = new Vector3(-transform.position.x, 0, transform.position.z);
    }
}
