using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

public class FileMove : ICommand
{
    public FileMove(IFileSystemController controller, Path sourcePath, Path destinationPath)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
        controller = controller ?? throw new ArgumentNullException(nameof(controller));

        Controller = controller;
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public Path SourcePath { get; }
    public Path DestinationPath { get; }
    public IFileSystemController Controller { get; }

    public void Execute()
    {
        Controller.FileMove(SourcePath, DestinationPath);
    }
}