using Unity.Entities;

namespace Jirushi.EntityBehaviours.Samples.RandomOperations.Components
{
    public struct OperationData : IComponentData
    {
        public float Value;
        public float MultiplicationResult;
        public float DivisionResult;
        public float ExponentialResult;
    }
}