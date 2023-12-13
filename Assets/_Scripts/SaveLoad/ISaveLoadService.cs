namespace _Scripts.SaveLoad
{
    public interface ISaveLoadService
    {
        void Save<T>();
        void Load<T>();
    }
}