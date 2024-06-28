using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    private LevelStorage _levelStorage;
    private LevelSpawner _levelSpawner;
    
    public void Awake()
    {
        _levelStorage = FindAnyObjectByType<LevelStorage>();
        _levelSpawner = FindAnyObjectByType<LevelSpawner>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(TagStorage.Player))
            return;

        _levelSpawner.SpawnLevel();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(TagStorage.Player))
            return;

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = false;

        _levelSpawner.DeleteLevel();

        _levelStorage.IncreasePassedLevels();

        Destroy(this);
    }
}