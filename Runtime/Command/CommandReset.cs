using System;

public class CommandReset<T> where T : ICommand
{
    public static Action<T> onReset;
    public static void Reset(T command)
    {
        onReset?.Invoke(command);
    }
}
