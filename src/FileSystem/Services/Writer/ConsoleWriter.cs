using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.Write(text);
    }
}