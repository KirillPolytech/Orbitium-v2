using UnityEngine;
using Zenject;

public class LevelContext : MonoInstaller
{
    [SerializeField] private MainPlayer mainPlayer;
    [SerializeField] private DragMovement dragMovement;
    [SerializeField] private StaminaController staminaController;
    [SerializeField] private FPS fps;
    [SerializeField] private InGameTime inGameTime;
    [SerializeField] private InGameWindowsController inGameWindowsController;
    [SerializeField] private InGameUI inGameUI;
    [SerializeField] private GamePlayEntryPoint gamePlayEntryPoint;
    [SerializeField] private BlackScreen blackScreen;
    [SerializeField] private LevelSpawner levelSpawner;
    [SerializeField] private LevelStorage levelStorage;
    
    public override void InstallBindings()
    {
        Container.BindInstance(mainPlayer).AsSingle();
        Container.BindInstance(dragMovement).AsSingle();
        Container.BindInstance(staminaController).AsSingle();
        Container.BindInstance(fps).AsSingle();
        Container.BindInstance(inGameTime).AsSingle();
        Container.BindInstance(inGameWindowsController).AsSingle();
        Container.BindInstance(gamePlayEntryPoint).AsSingle();
        Container.BindInstance(blackScreen).AsSingle();
        Container.BindInstance(levelSpawner).AsSingle();
        Container.BindInstance(levelStorage).AsSingle();
        Container.BindInstance(inGameUI).AsSingle();
        
        Container.Bind<InGameStateMachine>().FromNew().AsSingle();
    }
}