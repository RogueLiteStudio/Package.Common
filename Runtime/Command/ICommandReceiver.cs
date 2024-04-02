public interface ICommandReceiver
{
    T CreateCommand<T>() where T : ICommand, new();
    void Tick();
}
