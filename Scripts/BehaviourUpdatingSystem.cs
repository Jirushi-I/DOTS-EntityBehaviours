using Jirushi.EntityBehaviours.Samples.RandomOperations.Components;
using Unity.Collections;
using Unity.Entities;

namespace Jirushi.EntityBehaviours.Scripts
{
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    public class BehaviourUpdatingSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            NativeArray<Entity> entities = GetEntityQuery(typeof(OperationData), typeof(BehaviourComponent)).ToEntityArray(Allocator.TempJob);
        
            foreach (var entity in entities)
            {
                EntityManager.AddComponent<UpdatedBehaviourComponent>(entity);
            }
        
            entities.Dispose();
        }
    }
}