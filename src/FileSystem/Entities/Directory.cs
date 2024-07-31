using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;

public class Directory : IFileSystemElement
{
    private readonly List<IFileSystemElement> _data;

    public Directory(string name, Path path, IReadOnlyCollection<IFileSystemElement> data)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        data = data ?? throw new ArgumentNullException(nameof(data));

        Name = name;
        Path = path;
        _data = data.ToList();
    }

    public Directory(string name, Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));

        Name = name;
        Path = path;
        _data = new List<IFileSystemElement>();
    }

    public string Name { get; private set; }
    public Path Path { get; private set; }
    public IReadOnlyCollection<IFileSystemElement> Data => _data;

    public void Accept(IVisitor visitor)
    {
        visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));

        visitor.VisitDirectory(this);
    }
}