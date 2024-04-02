public class EmptyCommandReciver : ICommandReceiver
{
    public T CreateCommand<T>() where T : ICommand, new()
    {
        return default;
    }
    public void Tick()
    {
    }
}
