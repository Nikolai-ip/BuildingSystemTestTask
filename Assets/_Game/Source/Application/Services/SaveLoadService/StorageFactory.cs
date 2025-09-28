using System;
using System.Collections.Generic;
using _Game.Source.Application.Services.SaveLoadService.SaveLoadObjects;

namespace _Game.Source.Application.Services.SaveLoadService
{
    public abstract class StorageFactory
    {
        public abstract Dictionary<Type, ISaveLoadObject> GetDataStorages();
    }
}