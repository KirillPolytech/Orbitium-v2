using UnityEngine;
public class SpawnCollectables : MonoBehaviour
{
    float Timer = 0;
    public GameObject Collectables;
    Vector3 PositionRight, PositionLeft;
    void FixedUpdate()
    {
        if (Timer == 150)
        {
            Timer = 0;
            PositionRight = new(Camera.main.transform.position.x + Random.Range(50f, 100f), 0, Camera.main.transform.position.z + Random.Range(50f, 100f));
            PositionLeft = new(Camera.main.transform.position.x - Random.Range(50f, 100f), 0, Camera.main.transform.position.z - Random.Range(50f, 100f));
            if (Random.Range(-1f, 1f) >= 0)
            {
                Instantiate(Collectables, PositionRight, Quaternion.identity);
            }
            else
            {
                Instantiate(Collectables, PositionLeft, Quaternion.identity);
            }
        }
        Timer++;
    }
}
