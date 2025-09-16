using System;
using System.Collections.Generic;
using _Game.Scripts.Application.SavedData.BuildingSaveSystem;
using _Game.Scripts.Application.Services.SaveLoadService;
using _Game.Scripts.Application.Services.SaveLoadService.SaveLoadObjects;
using _Game.Scripts.Domain.Entities.Building;

namespace _Game.Scripts.Application.SavedData
{
    public class GameStorageFactory: StorageFactory
    {
        public override Dictionary<Type, ISaveLoadObject> GetDataStorages()
        {
            return new Dictionary<Type, ISaveLoadObject>()
            {
                {
                    typeof(BuildingSaveLoadDataStorage),
                    new BuildingSaveLoadDataStorage(new BuildingSaveLoadData(new List<BuildingParams>()))
                }
            };
        }
    }
}