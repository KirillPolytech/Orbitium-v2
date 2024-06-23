using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Range(0,100)][SerializeField] protected int valuable = 10;

    public int Value => valuable;
}
