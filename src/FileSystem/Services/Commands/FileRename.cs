using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

public class FileRename : ICommand
{
    public FileRename(IFileSystemController controller, Path path, string name)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        controller = controller ?? throw new ArgumentNullException(nameof(controller));

        Controller = controller;
        Path = path;
        Name = name;
    }

    public Path Path { get; }
    public string Name { get; }
    public IFileSystemController Controller { get; }

    public void Execute()
    {
        Controller.FileRename(Path, Name);
    }
}