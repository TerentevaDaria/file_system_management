using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

public class FileShow : ICommand
{
    public FileShow(IFileSystemController controller, Path path, IWriter writer)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        writer = writer ?? throw new ArgumentNullException(nameof(writer));
        controller = controller ?? throw new ArgumentNullException(nameof(controller));

        Controller = controller;
        Path = path;
        Writer = writer;
    }

    public Path Path { get; }
    public IWriter Writer { get; }
    public IFileSystemController Controller { get; }

    public void Execute()
    {
        Controller.FileShow(Path, Writer);
    }
}