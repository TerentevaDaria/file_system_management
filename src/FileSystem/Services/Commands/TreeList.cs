using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

public class TreeList : ICommand
{
    public TreeList(IFileSystemController controller, int depth, IWriter writer, Configurator configurator)
    {
        if (depth < 0) throw new NotPositiveValueException(nameof(depth));
        controller = controller ?? throw new ArgumentNullException(nameof(controller));
        writer = writer ?? throw new ArgumentNullException(nameof(writer));
        configurator = configurator ?? throw new ArgumentNullException(nameof(configurator));

        Controller = controller;
        Depth = depth;
        Writer = writer;
        Configurator = configurator;
    }

    public int Depth { get; }
    public IWriter Writer { get; }
    public Configurator Configurator { get; }
    public IFileSystemController Controller { get; }

    public void Execute()
    {
        Controller.TreeList(Depth, Writer, Configurator);
    }
}