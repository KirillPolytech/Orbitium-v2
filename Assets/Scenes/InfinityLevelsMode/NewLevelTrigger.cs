using UnityEngine;

public class NewLevelTrigger : MonoBehaviour
{
    private GameObject _tempLevelGameObject;
    private static int __stepBetweenLevels = 50;
    private static int __index = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Player>())
            return;

        _tempLevelGameObject = Instantiate( 
            LevelStorage.GetInstance.GetLevelPrefab(Random.Range(0, LevelStorage.GetInstance.GetLevelsPrefabsLength())));

        _tempLevelGameObject.transform.position = new Vector3(0, 0, __stepBetweenLevels);
        __stepBetweenLevels += 100;

        LevelStorage.GetInstance.AddLevelToList(transform.parent.gameObject);
        LevelStorage.GetInstance.DeleteLevel(__index - 1);
        Debug.Log("index: " + (__index - 2));

        __index++;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Player>())
            return;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = false;
        Destroy(GetComponent<NewLevelTrigger>());
    }
}
