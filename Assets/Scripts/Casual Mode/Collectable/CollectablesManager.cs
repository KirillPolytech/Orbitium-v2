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
// private static int CollectedCollactables; Количество всех собранных сфер
/*
public void IncreaseCollectables()
{
    CollectedCollactables++;
}
*/
