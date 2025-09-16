using System;
using VContainer.Unity;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingRemover: IInitializable, IDisposable
    {
        private BuildingFSM _fsm;
        private IDisposable _sub;
        private GameObject _buildingGameObject;

        public BuildingRemover(BuildingFSM fsm, GameObject buildingGameObject)
        {
            _fsm = fsm;
            _buildingGameObject = buildingGameObject;
        }

        public void Initialize()
        {
            _sub = _fsm.State.Subscribe(OnStateChanged);
        }

        private void OnStateChanged(BuildingState state)
        {
            if (state == BuildingState.Remove)
            {
                Object.Destroy(_buildingGameObject);
            }
        }

        public void Dispose()
        {
            _sub.Dispose();
        }
    }
}