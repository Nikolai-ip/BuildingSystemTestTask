namespace _Game.Scripts.Application.Services.SaveLoadService.SaveLoadObjects
{
    public interface ISaveLoadObject
    {
        public string ComponentID { get; }
        public SaveLoadData SaveLoadData { get;}
        public void RestoreValues(SaveLoadData saveLoadData);
        ISaveLoadObject Clone();
    }
}