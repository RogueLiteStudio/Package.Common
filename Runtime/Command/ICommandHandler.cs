public interface ICommandHandler
{
    /// <summary>
    /// 处理命令
    /// </summary>
    /// <param name="id">命令ID</param>
    /// <param name="command">命令</param>
    /// <returns>true:命令被处理，继续下一个，false 不满足处理条件，中断当前tick的命令处理</returns>
    bool HandleCommand(int id, ICommand command);
}
