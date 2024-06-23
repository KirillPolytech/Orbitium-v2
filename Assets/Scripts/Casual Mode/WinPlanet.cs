using UnityEngine;

public class WinPlanet : MonoBehaviour
{
    [SerializeField] Material _deactiveMaterial;
    [SerializeField] Material _activeMaterial;

    private GameObject _playerGameObject;
    private Player _player;
    private Material _currentMaterial;
    private void Start()
    {
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _player = _playerGameObject.GetComponent<Player>();

        _currentMaterial = GetComponent<MeshRenderer>().material;
    }
    private void FixedUpdate()
    {
        if (_player.Collectables != CollectablesManager.GetCountOfCollectables())
            _currentMaterial = _deactiveMaterial;
        else
            _currentMaterial = _activeMaterial;
        GetComponent<MeshRenderer>().material = _currentMaterial;
    }
}
