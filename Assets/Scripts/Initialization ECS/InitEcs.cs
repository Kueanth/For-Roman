using UnityEngine;
using Leopotam.Ecs;

public class InitEcs : MonoBehaviour
{
    [SerializeField] private SceneData sceneData; 
    [SerializeField] private StaticData configuration;

    private EcsWorld _world;

    private EcsSystems _awakeSystems;
    private EcsSystems _startSystems;
    private EcsSystems _fixedSystems;
    private EcsSystems _updateSystems;
    private EcsSystems _lateSystems;

    private void Awake()
    {

        _world = new EcsWorld();

        _awakeSystems = new EcsSystems(_world);
        _startSystems = new EcsSystems(_world);
        _fixedSystems = new EcsSystems(_world);
        _updateSystems = new EcsSystems(_world);
        _lateSystems = new EcsSystems(_world);

        _awakeSystems
            .Add(new LevelInit())
            .Add(new AnimalInit())
            .Inject(configuration)
            .Inject(sceneData)
            .Init();

        _startSystems
            .Inject(configuration)
            .Inject(sceneData)
            .Init();

        _fixedSystems
            .Init();

        _updateSystems
            .Inject(configuration)
            .Inject(sceneData)
            .Init();

        _lateSystems
            .Inject(sceneData)
            .Inject(configuration)
            .Init();

        _awakeSystems.Run();
    }

    private void Start()
    {
        _startSystems.Run();
    }

    private void FixedUpdate()
    {
        _fixedSystems.Run();
    }

    private void Update()
    {
        _updateSystems.Run();
    }

    private void LateUpdate()
    {
        _lateSystems.Run();
    }

    private void OnDestroy()
    {
        _awakeSystems.Destroy();
        _startSystems.Destroy();
        _fixedSystems.Destroy();
        _updateSystems.Destroy();
        _lateSystems.Destroy();
    }
}
