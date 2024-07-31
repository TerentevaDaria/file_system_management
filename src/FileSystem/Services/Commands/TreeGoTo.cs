﻿using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

public class TreeGoTo : ICommand
{
    public TreeGoTo(IFileSystemController controller, Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        controller = controller ?? throw new ArgumentNullException(nameof(controller));

        Controller = controller;
        Path = path;
    }

    public Path Path { get; }
    public IFileSystemController Controller { get; }

    public void Execute()
    {
        Controller.TreeGoTo(Path);
    }
}