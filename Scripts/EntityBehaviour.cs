using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace Jirushi.EntityBehaviours.Scripts
{
    public abstract class EntityBehaviour : MonoBehaviour
    {
        private EntityManager _entityManager;
        private Entity _entity;

        private void TryInit()
        {
            if(_entityManager != null) return;
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
         
            _entity = _entityManager.CreateEntity();
            _entityManager.SetName(_entity, name + "." + GetType());
            _entityManager.AddComponentData(_entity, new BehaviourComponent());
        }
     
        protected void CreateComponentData<TComponentData>() where TComponentData : struct, IComponentData
        {
            TryInit();
            _entityManager.AddComponentData(_entity, new TComponentData());
        }

        protected TComponentData GetComponentData<TComponentData>() where TComponentData : struct, IComponentData
        {
            return _entityManager.GetComponentData<TComponentData>(_entity);
        }

        protected void UpdateComponentData<TComponentData>(TComponentData componentData) where TComponentData : struct, IComponentData
        {
            _entityManager.SetComponentData(_entity, componentData);
            AwaitCall();
        }

        async void AwaitCall()
        {
            while (!_entityManager.HasComponent<UpdatedBehaviourComponent>(_entity))
            {
                await Task.Yield();
            }
         
            _entityManager.RemoveComponent<UpdatedBehaviourComponent>(_entity);
            OnEntityUpdate();
        }

        protected virtual void OnEntityUpdate() { }
    }
}