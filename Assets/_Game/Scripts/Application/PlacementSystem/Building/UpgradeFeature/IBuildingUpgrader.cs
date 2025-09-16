using System;

namespace _Game.Scripts.Application.PlacementSystem.Building.UpgradeFeature
{
    public interface IBuildingUpgrader
    {
        void Upgrade();
        event Action OnUpgraded;
    }
}