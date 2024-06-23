using UnityEngine;

public class MovementDirectionLine : MonoBehaviour
{
    [SerializeField] private LineRenderer Line;
    private void Start()
    {
        Line.useWorldSpace = true;
        Line.startWidth = 1f;
        Line.endWidth = 0.3f;

        MainPlayer.Instance.EventAtDeath += ResetLinePosition;
    }

    public void SetLinePosition(RaycastHit hit, GameObject player)
    {
        Line.SetPosition(0, player.transform.position);
        Line.SetPosition(1, new Vector3(hit.point.x, 0, hit.point.z));
    }

    public void ResetLinePosition()
    {
        Line.SetPosition(0, new Vector3(-50, -50, -50));
        Line.SetPosition(1, new Vector3(-50, -50, -50));
    }
}
