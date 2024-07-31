using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;

public class File : IFileSystemElement
{
    public File(string name, Path path, string data)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));

        Name = name;
        Path = path;
        Data = data;
    }

    public File(string name, Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));

        Name = name;
        Path = path;
        Data = string.Empty;
    }

    public string Name { get; private set; }
    public Path Path { get; private set; }
    public string Data { get; private set; }

    public void Accept(IVisitor visitor)
    {
        visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));

        visitor.VisitFile(this);
    }
}