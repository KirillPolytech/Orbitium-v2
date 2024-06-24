using UnityEngine;

public class WinPlanet : MonoBehaviour
{
    [SerializeField] Material _deactiveMaterial;
    [SerializeField] Material _activeMaterial;

    private MainPlayer _player;
    private Material _currentMaterial;

    private void Start()
    {
        //_player = MainPlayer.Instance.GetComponent<MainPlayer>();

        _currentMaterial = GetComponent<MeshRenderer>().material;
    }

    private void FixedUpdate()
    {
        _currentMaterial = _player.Collectables != CollectablesManager.GetCountOfCollectables()
            ? _deactiveMaterial
            : _activeMaterial;
        GetComponent<MeshRenderer>().material = _currentMaterial;
    }
}