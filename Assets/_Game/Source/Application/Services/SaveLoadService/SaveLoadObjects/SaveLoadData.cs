using System;

namespace _Game.Source.Application.Services.SaveLoadService.SaveLoadObjects
{
    [Serializable]
    public class SaveLoadData
    {
        public SaveLoadData(object[] data, string id)
        {
            Data = data;
            Id = id;
        }

        public void Update<TSaved>(params TSaved[] savedObjects)
        {
            Data = new object[savedObjects.Length];
            for (var i = 0; i < savedObjects.Length; i++)
                Data[i] = savedObjects[i];
        }
        public object[] Data { get; protected set; }
        public string Id { get; protected set; }
    }
}