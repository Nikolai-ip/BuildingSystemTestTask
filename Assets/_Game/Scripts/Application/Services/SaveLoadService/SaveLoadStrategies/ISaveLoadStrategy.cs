using System.Collections.Generic;
using _Game.Scripts.Application.Services.SaveLoadService.SaveLoadObjects;

namespace _Game.Scripts.Application.Services.SaveLoadService.SaveLoadStrategies
{
    public interface ISaveLoadStrategy
    {
        public void Save(IEnumerable<ISaveLoadObject> objectsToSave);
        public SaveLoadData[] Load();
    }
}