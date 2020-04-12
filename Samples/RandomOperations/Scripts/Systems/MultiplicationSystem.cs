using Jirushi.EntityBehaviours.Samples.RandomOperations.Components;
using Jirushi.EntityBehaviours.Scripts;
using Unity.Entities;
using Unity.Jobs;

namespace Jirushi.EntityBehaviours.Samples.RandomOperations.Systems
{
    public class MultiplicationSystem : JobComponentSystem
    {

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle = Entities.WithNone<UpdatedBehaviourComponent>().ForEach((ref OperationData operation) =>
                {
                    operation.MultiplicationResult = operation.Value * 2;
                })
                .Schedule(inputDeps);

        
            return jobHandle;
        }
    }
}