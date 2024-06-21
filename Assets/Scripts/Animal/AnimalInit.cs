using UnityEngine;
using Leopotam.Ecs;
using System.Linq;
using System.Collections.Generic;

public class AnimalInit : IEcsInitSystem
{
    private SceneData sceneData;
    private StaticData configuration;

    private EcsWorld _world;

    public void Init()
    {
        ref Level ComponentsLevel = ref sceneData.EntityLevel.Get<Level>();

        int temp = 0;

        for (int i = 0; i < sceneData.N; i++)
        {
            HashSet<int> exlude = new HashSet<int>();

            for(int j = 0; j < sceneData.N / sceneData.M; j++)
            {
                if (temp >= sceneData.M) break;

                int PointX = RandomFromRangeWithExceptions(0, sceneData.N, exlude);

                EcsEntity Entity = _world.NewEntity();

                ref Animal Components = ref Entity.Get<Animal>();

                Vector3 position = new Vector3(PointX, 0, i);

                GameObject animalObject = GameObject.Instantiate(configuration.Animal, position, Quaternion.identity);
                animalObject.transform.SetParent(sceneData.ParentAnimal);

                Components.gameObject = animalObject;

                exlude.Add(PointX);

                ++temp;
            }
        }
    }

    private int RandomFromRangeWithExceptions(int rangeMin, int rangeMax, HashSet<int> exclude)
    {
        var range = Enumerable.Range(rangeMin, rangeMax).Where(i => !exclude.Contains(i));
        int index = Random.Range(rangeMin, rangeMax - exclude.Count);
        return range.ElementAt(index);
    }
}
