using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);

        while (true)
        {
            string? input = Console.ReadLine();
            if (input is null) continue;
            try
            {
                ICommand? result = parser.TryParsing(input.Split());
                if (result is null)
                {
                    Console.WriteLine("unknown command");
                    continue;
                }

                result.Execute();
            }
            catch (FileSystemException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileSystemNotConnectedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ParserException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}