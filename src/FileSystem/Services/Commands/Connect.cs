using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

public class Connect : ICommand
{
    public Connect(IFileSystemController controller, Path address, Mode mode)
    {
        address = address ?? throw new ArgumentNullException(nameof(address));
        controller = controller ?? throw new ArgumentNullException(nameof(controller));

        Controller = controller;
        Address = address;
        Mode = mode;
    }

    public Path Address { get; }
    public Mode Mode { get; }
    public IFileSystemController Controller { get; }

    public void Execute()
    {
        Controller.Connect(Address, Mode);
    }
}