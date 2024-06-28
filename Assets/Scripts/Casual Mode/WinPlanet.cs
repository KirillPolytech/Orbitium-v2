using UnityEngine;
using Zenject;

public class WinPlanet : MonoBehaviour
{
    [SerializeField] Material _deactiveMaterial;
    [SerializeField] Material _activeMaterial;

    private MainPlayer _player;
    private MeshRenderer _meshRenderer;

    [Inject]
    public void Construct(MainPlayer player)
    {
        _player = player;
        
        _meshRenderer = GetComponent<MeshRenderer>();

        _player.EventAtCollect += Activate;
    }

    private void Activate(int collectablesAmount)
    {
        if (collectablesAmount != CollectablesManager.GetCountOfCollectables())
            return;

        _meshRenderer.material = _activeMaterial;
    }
}