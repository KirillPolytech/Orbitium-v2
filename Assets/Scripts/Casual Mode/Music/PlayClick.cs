using UnityEngine;

public class PlayClick : MonoBehaviour
{
    public AudioSource Click;
    public void PlayClickSound()
    {
        Click.Play();
    }
}
