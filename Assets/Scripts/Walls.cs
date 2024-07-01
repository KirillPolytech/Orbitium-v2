using UnityEngine;
[ExecuteInEditMode]
public class Walls : MonoBehaviour
{
    public bool IsTransformingRounding = true;
    public bool IsScalingRounding = true;

    private void Update()
    {   
        if (IsTransformingRounding)
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        if (IsScalingRounding)
            transform.localScale = new Vector3(Mathf.Round(transform.localScale.x), Mathf.Round(transform.localScale.y), Mathf.Round(transform.localScale.z));
    }
}
