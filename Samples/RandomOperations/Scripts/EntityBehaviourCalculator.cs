using Jirushi.EntityBehaviours.Samples.RandomOperations.Components;
using Jirushi.EntityBehaviours.Scripts;
using UnityEngine;

namespace Jirushi.EntityBehaviours.Samples.RandomOperations
{
    public class EntityBehaviourCalculator : EntityBehaviour
    {
        [SerializeField] private float value;
        [Header("Results")]
        [SerializeField] private float multiplication;
        [SerializeField] private float division;
        [SerializeField] private float exponent;

        private void OnEnable()
        {
            CreateComponentData<OperationData>();
        }

        private void Update()
        {
            UpdateComponentData(new OperationData{Value = value});
        }

        protected override void OnEntityUpdate()
        {
            var data = GetComponentData<OperationData>();
            multiplication = data.MultiplicationResult;
            division = data.DivisionResult;
            exponent = data.ExponentialResult;
        }
    }
}