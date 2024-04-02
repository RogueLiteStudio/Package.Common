using System.Collections;
using System.Collections.Generic;

public class CommandReciverQueue : ICommandReceiver
{
    private struct CommandData
    {
        public ICommand Command;
        public int CommandId;
        public IList Pool;
    }
    private Queue<CommandData> commands = new Queue<CommandData>();

    private ICommandHandler commandHandler;

    public void SetCommandHandler(ICommandHandler handler)
    {
        commandHandler = handler;
    }

    public T CreateCommand<T>() where T : ICommand, new()
    {
        var command = CommandPool<T>.Get();
        commands.Enqueue(new CommandData
        {
            Command = command,
            CommandId = CommandIdentity<T>.Id,
            Pool = CommandPool<T>.GetPool(),
        });
        return command;
    }

    public void Tick()
    {
        while (commands.TryPeek(out var data))
        {
            if (commandHandler.HandleCommand(data.CommandId, data.Command))
            {
                commands.Dequeue();
                data.Pool.Add(data.Command);
            }
            else
            {
                break;
            }
        }
    }

}
