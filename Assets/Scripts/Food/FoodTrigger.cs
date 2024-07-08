using UnityEngine;
using Leopotam.Ecs;

public class FoodTrigger : MonoBehaviour
{
    public ParticleSystem particleUp;

    public EcsEntity entityAnimal;
    public EcsEntity entityFood;

    public SceneData sceneData;

    private void OnTriggerEnter(Collider other)
    {
        if (entityAnimal.Get<Animal>().gameObject.transform.GetInstanceID() == other.transform.GetInstanceID())
        {
            sceneData.pointX.Remove(entityFood.Get<Food>().PositionX);
            sceneData.pointZ.Remove(entityFood.Get<Food>().PositionZ);

            entityAnimal.Get<FoodInitialization>();

            ParticleSystem particle = 
                GameObject.Instantiate(particleUp, gameObject.transform.position, Quaternion.identity);

            particle.transform.parent = null;
   
            GameObject.Destroy(gameObject);
        }
    }
}
