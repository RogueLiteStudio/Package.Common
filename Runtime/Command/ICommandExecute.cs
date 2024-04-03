
public interface ICommandExecute<TContext>
{
    void Execute(TContext context, ICommand command);
}

/*
public abstract class XXCommandExecute<TCommand> : ICommandExecute<XXX> where TCommand : ICommand, class
{
    public void Execute(XXX context, ICommand command)
    {
        OnExcute(context, command as TCommand);
    }

    protected abstract void OnExcute(XXX context, TCommand command);
}
*/