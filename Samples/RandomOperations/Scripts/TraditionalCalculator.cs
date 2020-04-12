using UnityEngine;

namespace Jirushi.EntityBehaviours.Samples.RandomOperations
{
    public class TraditionalCalculator : MonoBehaviour
    {
        [SerializeField] private float value;
        [Header("Results")]
        [SerializeField] private float multiplication;
        [SerializeField] private float division;
        [SerializeField] private float exponent;

        private void Update()
        {
            multiplication = value * 2;
            division = value / 2;
            exponent = value * value;
        }
    }
}