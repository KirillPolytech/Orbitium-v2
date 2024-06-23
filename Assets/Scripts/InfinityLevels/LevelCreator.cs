using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false)
            return;

        LevelSpawner.Instance.SpawnLevel();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == false)
            return;

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().isTrigger = false;

        LevelSpawner.Instance.DeleteLevel();

        LevelsStorage.Instance.IncreasePassedLevels();

        Destroy(this);
    }
}