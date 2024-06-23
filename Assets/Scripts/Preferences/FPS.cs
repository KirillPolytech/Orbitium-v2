using UnityEngine;

public class FPS : MonoBehaviour
{
    private float deltaTime;
    private UIManager UI;
    private void OnLevelWasLoaded(int level)
    {
        UI = FindAnyObjectByType<UIManager>();
    }

    private void Update()
    {
        FPSCounter();
    }

    private void FPSCounter()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        UI.UpdateFPSCounter(deltaTime);

    }
}
