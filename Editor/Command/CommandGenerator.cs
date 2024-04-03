using CodeGen;
using System;
using System.Collections.Generic;

public static class CommandGenerator
{
    public class CommandInfo
    {
        public List<Type> Types;
        public Type CommandBaseType;
        public string ContextName;
    }

    public static void GenCommand<TCommand, TExecuteContext, TExecute>(string externPayh, string executePath) where TCommand : ICommand
    {
        var types = TypeCollector<TCommand>.Types;
        CommandInfo info = new CommandInfo();
        info.Types = types;
        info.CommandBaseType = typeof(TCommand);
        info.ContextName = typeof(TCommand).Name;
        CommandExternGenerator.GenExtern(externPayh, info);
    }

}
