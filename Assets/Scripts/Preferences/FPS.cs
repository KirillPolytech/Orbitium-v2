using UnityEngine;

public class FPS : MonoBehaviour
{
    public float DeltaTime { get; private set; }

    private void Update()
    {
        FPSCounter();
    }

    private void FPSCounter()
    {
        DeltaTime = (int)(1f / Time.unscaledDeltaTime); //+= (Time.deltaTime - DeltaTime) * 0.1f;
    }
}