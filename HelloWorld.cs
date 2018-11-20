using System;
using System.IO;
using AppUtil;
[Executable(ExecuteName = "hw", FuncDesc = "Hello World!", Order = 1)]
public class Hello : CmdExecuter
{
    public override void Execute()
    {
        Console.WriteLine("Hello World!");
    }
}