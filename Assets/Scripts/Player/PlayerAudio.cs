using UnityEngine;
using Zenject;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource hitSound;

    [Inject]
    public void Construct(MainPlayer player)
    {
        player.EventAtCollision += hitSound.Play;
    }
}