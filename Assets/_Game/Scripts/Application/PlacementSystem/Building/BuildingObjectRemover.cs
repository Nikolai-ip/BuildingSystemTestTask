using System;
using VContainer.Unity;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.Application.PlacementSystem.Building
{
    public class BuildingObjectRemover: IInitializable, IDisposable
    {
        private readonly BuildingFSM _fsm;
        private readonly GameObject _buildingGameObject;
        private readonly IBuildingRemover _buildingRemover;
        private IDisposable _sub;

        public BuildingObjectRemover(BuildingFSM fsm, GameObject buildingGameObject, IBuildingRemover buildingRemover)
        {
            _fsm = fsm;
            _buildingGameObject = buildingGameObject;
            _buildingRemover = buildingRemover;
        }

        public void Initialize()
        {
            _sub = _fsm.State.Subscribe(OnStateChanged);
        }

        private void OnStateChanged(BuildingState state)
        {
            if (state == BuildingState.Remove)
            {
                _buildingRemover.RemoveObject();
                Object.Destroy(_buildingGameObject);
            }
        }

        public void Dispose()
        {
            _sub.Dispose();
        }
    }
}