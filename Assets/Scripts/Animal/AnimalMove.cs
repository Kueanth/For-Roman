using UnityEngine;
using Leopotam.Ecs;
using System.Collections;

public class AnimalMove : IEcsRunSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    private EcsWorld _world;

    private EcsFilter<Animal>.Exclude<FoodInitialization> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var ComponentsAnimal = ref _filter.Get1(i);

            ComponentsAnimal.gameObject.transform.position = 
                Vector3.MoveTowards(ComponentsAnimal.gameObject.transform.position, 
                ComponentsAnimal.target.transform.position, 0.01f * sceneData.V * Time.deltaTime);

            _filter.GetEntity(i).Del<FoodInitialization>();
        }
    }
}
