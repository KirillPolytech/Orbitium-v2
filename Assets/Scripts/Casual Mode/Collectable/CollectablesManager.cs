using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    private static GameObject[] Collectables;
    
    private void Start()
    {
        Collectables = GameObject.FindGameObjectsWithTag("Collectables");
    }
    
    public static int GetCountOfCollectables()
    {
        return Collectables.Length;
    }
}
