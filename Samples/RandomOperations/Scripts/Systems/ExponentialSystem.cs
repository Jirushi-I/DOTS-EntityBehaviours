using Jirushi.EntityBehaviours.Samples.RandomOperations.Components;
using Jirushi.EntityBehaviours.Scripts;
using Unity.Entities;
using Unity.Jobs;

namespace Jirushi.EntityBehaviours.Samples.RandomOperations.Systems
{
    public class ExponentialSystem : JobComponentSystem
    {

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle = Entities.WithNone<UpdatedBehaviourComponent>().ForEach((ref OperationData operation) =>
                {
                    operation.ExponentialResult = operation.Value * operation.Value;
                })
                .Schedule(inputDeps);

        
            return jobHandle;
        }
    }
}