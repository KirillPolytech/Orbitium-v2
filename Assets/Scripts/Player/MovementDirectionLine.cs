using UnityEngine;

public class MovementDirectionLine : MonoBehaviour
{
    [SerializeField] private LineRenderer Line;

    private MainPlayer _mainPlayer;
    
    private void Start()
    {
        _mainPlayer = GetComponent<MainPlayer>();
        
        Line.useWorldSpace = true;
        Line.startWidth = 1f;
        Line.endWidth = 0.3f;

        _mainPlayer.EventAtDeath += ResetLinePosition;
    }

    public void SetLinePosition(RaycastHit hit, GameObject player)
    {
        Line.SetPosition(0, player.transform.position);
        Line.SetPosition(1, new Vector3(hit.point.x, 0, hit.point.z));
        Line.enabled = true;
    }

    public void ResetLinePosition()
    {
        Line.enabled = false;
    }
}
