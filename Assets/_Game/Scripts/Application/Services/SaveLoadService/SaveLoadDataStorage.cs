using System;
using System.Collections.Generic;
using System.Linq;
using _Game.Scripts.Application.Services.SaveLoadService.SaveLoadObjects;
using Unity.Plastic.Newtonsoft.Json.Linq;

namespace _Game.Scripts.Application.Services.SaveLoadService
{
    public abstract class SaveLoadDataStorage: ISaveLoadObject
    {
        public string ComponentID => SaveLoadData.GetType().Name;
        public SaveLoadData SaveLoadData { get; protected set; }

        protected SaveLoadDataStorage(SaveLoadData saveLoadData)
        {
            SaveLoadData = saveLoadData;
        }
        protected TSaved GetSavedData<TSaved>()
        {
            if (SaveLoadData.Data[0] is TSaved savedData)
                return savedData;
            
            throw new ArgumentException($"Invalid saved data type: {typeof(TSaved)}. The real type is: {SaveLoadData.GetType()}");
        }
        
        protected List<TSaved> GetSavedList<TSaved>() where TSaved : class
        {
            return SaveLoadData.Data
                .OfType<TSaved>() 
                .ToList();
        }

        public abstract void RestoreValues(SaveLoadData saveLoadData);

        protected TSaved RestoreValue<TSaved>(SaveLoadData saveLoadData)
        {
            JToken token = (JToken)saveLoadData.Data[0];
            var restoredData = token.ToObject<TSaved>();
            SaveLoadData.Update(restoredData);
            return restoredData;
        }

        protected List<TBase> RestoreListValues<TBase>(SaveLoadData saveLoadData, params Type[] types) where TBase : class        
        {   
            var list = new List<TBase>();

            for (int i = 0; i < types.Length; i++)
            {
                Type targetType = types[i];
                if (!typeof(TBase).IsAssignableFrom(targetType))
                    throw new InvalidOperationException(
                        $"Type {targetType.Name} is not assignable to {typeof(TBase).Name}");
                JToken token = (JToken)saveLoadData.Data[i];
                var restored = (TBase)token.ToObject(targetType);
                list.Add(restored);
            }
            SaveLoadData.Update(list.ToArray());
            return list;
        }
        
        public virtual ISaveLoadObject Clone()
        {
            return MemberwiseClone() as SaveLoadDataStorage;
        }
    }
}