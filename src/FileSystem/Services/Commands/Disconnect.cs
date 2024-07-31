using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

public class Disconnect : ICommand
{
    public Disconnect(IFileSystemController controller)
    {
        Controller = controller ?? throw new ArgumentNullException(nameof(controller));
    }

    public IFileSystemController Controller { get; }

    public void Execute()
    {
        Controller.Disconnect();
    }
}