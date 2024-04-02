public interface ICommandExecute<TContext, TCommand> where TCommand : ICommand
{
    void Execute(TContext context, TCommand command);
}
