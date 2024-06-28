using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(transform.right,1);
    }
}
