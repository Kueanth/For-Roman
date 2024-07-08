using UnityEngine;
using Leopotam.Ecs;

public class LevelInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    private EcsWorld _world;

    public void Init()
    {
        EcsEntity Entity = _world.NewEntity();

        ref Level Components = ref Entity.Get<Level>();

        Vector3 scale;

        scale = new Vector3((sceneData.N / 10f) + 0.1f, 0.1f, (sceneData.N / 10f) + 0.1f);

        Vector3 position = new Vector3((sceneData.N / 2) - 0.5f, -0.4f, (sceneData.N / 2) - 0.5f);

        GameObject levelObject = GameObject.Instantiate(configuration.Point, position, Quaternion.identity);
        levelObject.transform.localScale = scale;
    }
}
