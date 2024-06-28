using UnityEngine;

public class ClusterRotatioAroundCenter : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private float r = 15f;
    [SerializeField] private float rotationSpeed = 0.02f;
    [SerializeField] private float k;

    [SerializeField] private bool isRadiusChange;
    [SerializeField] private float minR;
    [SerializeField] private float maxR;
    [SerializeField] private float radiusChangeSpeed = 0.5f;

    [SerializeField] private Vector3 _center = Vector3.zero;

    private float x, z;
    private float angle;
    private int i;
    private bool isMax;
    private void FixedUpdate()
    {
        if (isRadiusChange)
        {
            if (r <= maxR && !isMax)
            {
                r = Mathf.Clamp(r += radiusChangeSpeed, minR, maxR);
            }
            if (r >= maxR || isMax)
            {
                r = Mathf.Clamp(r -= radiusChangeSpeed, minR, maxR);
                isMax = true;
            }
            if (r <= minR)
                isMax = false;
        }
        i = 0;
        foreach (var star in _gameObjects)
        {
            angle += rotationSpeed * Time.fixedDeltaTime;
            x = Mathf.Cos(angle + k * i) * r;
            z = Mathf.Sin(angle + k * i) * r;
            star.transform.position = new Vector3(x, 0, z) + _center;
            i++;
        }
    }
}
