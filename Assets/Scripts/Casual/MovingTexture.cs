using UnityEngine;

public class MovingTexture : MonoBehaviour
{
    public float ScrollSpeed = 0.0001f;
    private Renderer rend;
    private float offset = 0; 
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void FixedUpdate()
    {
        offset += ScrollSpeed;
        rend.material.SetTextureOffset( "_MainTex", new Vector2(offset, 0) );
    }
}
