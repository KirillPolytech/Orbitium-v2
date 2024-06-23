using System.Collections.Generic;
using UnityEngine;

public class CollectablesCounter
{
    private static List<GameObject> Collectables = new List<GameObject>();

    public static int GetAmount()
    {
        return Collectables.Count;
    }

    public static void AddCollectablesToList(GameObject coll)
    {
        Collectables.Add(coll);
    }
}