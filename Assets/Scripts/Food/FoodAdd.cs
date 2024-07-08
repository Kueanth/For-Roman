using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodAdd : IEcsRunSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    private EcsWorld _world;

    private EcsFilter<Animal, FoodInitialization> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var ComponentsAnimal = ref _filter.Get1(i);

            int PointX = RandomFromRangeWithExceptions(0, sceneData.N, sceneData.pointX);
            int PointZ = RandomFromRangeWithExceptions(0, sceneData.N, sceneData.pointZ);

            EcsEntity Entity = _world.NewEntity();

            ref Food Components = ref Entity.Get<Food>();

            Vector3 position = new Vector3(PointX, 0, PointZ);

            GameObject foodObject = GameObject.Instantiate(configuration.Food, position, Quaternion.identity);
            foodObject.transform.SetParent(sceneData.ParentFood);

            Components.PositionX = PointX;
            Components.PositionZ = PointZ;

            Components.gameObject = foodObject;

            sceneData.pointX.Add(PointX);
            sceneData.pointZ.Add(PointZ);

            ComponentsAnimal.target = foodObject;

            foodObject.GetComponent<FoodTrigger>().entityAnimal = _filter.GetEntity(i);
            foodObject.GetComponent<FoodTrigger>().entityFood = Entity;

            foodObject.GetComponent<FoodTrigger>().sceneData = sceneData;

            _filter.GetEntity(i).Del<FoodInitialization>();
        }
    }

    private int RandomFromRangeWithExceptions(int rangeMin, int rangeMax, HashSet<int> exclude)
    {
        try
        {
            var range = Enumerable.Range(rangeMin, rangeMax).Where(i => !exclude.Contains(i));
            int index = UnityEngine.Random.Range(rangeMin, rangeMax - exclude.Count);
            return range.ElementAt(index);
        }
        finally
        {
            sceneData.pointX.Clear();
            sceneData.pointZ.Clear();
        }
    }
}
